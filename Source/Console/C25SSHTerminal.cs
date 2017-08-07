using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Renci.SshNet;

namespace PowerSDR
{
    public partial class C25SSHTerminalForm : Form
    {
        private Thread sshterminal_thread;
        private SshClient sshclient = null;
        private Shell sshshell = null;
        private string input = "";
        private MemoryStream output = new MemoryStream();

        public C25SSHTerminalForm(Setup setup)
        {
            InitializeComponent();

            var connectionInfo = new ConnectionInfo(JanusAudio.Metis_IP_address, "root", new PasswordAuthenticationMethod("root", "root"));

            sshclient = new SshClient(connectionInfo);
            {
                sshclient.Connect();

                if (sshclient.IsConnected)
                {
                    // sshshell = sshclient.CreateShellStream("SSH Terminal", 80, 24, 640, 480, 1024);
                    sshshell = sshclient.CreateShell(Encoding.ASCII, input, output, output);
                    sshshell.Start();


                    if (sshterminal_thread == null || !sshterminal_thread.IsAlive)
                    {
                        sshterminal_thread = new Thread(new ThreadStart(sshterminal_update));
                        sshterminal_thread.Name = "SSH Terminal Thread";
                        sshterminal_thread.Priority = ThreadPriority.Normal;
                        sshterminal_thread.IsBackground = false;
                        sshterminal_thread.Start();
                    }

                }
            }
        }

        private void sshterminal_update()
        {
            // while new data from the SSH server are available process them
            while (output.Length > 0) 
            {
                var result = new StreamReader(output, Encoding.ASCII).ReadToEnd();                
                tbC25SSHTerminalOutput.AppendText(result);
                output.SetLength(0);
            }

            // Application.DoEvents();
            // Thread.Sleep(1000);
        }

        private void tbC25SSHTerminalInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keyboard.IsKeyDown(Keys.Enter))
            {
                tbC25SSHTerminalInput.Text += "\n";

                // SshCommand sc = sshclient.CreateCommand(tbC25SSHTerminalInput.Text);
                // sc.Execute();                

                input = tbC25SSHTerminalInput.Text;
                tbC25SSHTerminalOutput.AppendText(tbC25SSHTerminalInput.Text);
                tbC25SSHTerminalInput.Clear();

                // tbC25SSHTerminalOutput.AppendText(sc.Result);                
            }            
        }

        private void C25SSHTerminalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sshterminal_thread.Abort();
            sshshell.Stop();            
            sshclient.Disconnect();
        }
    }
}
