//=================================================================
// C25SSHTerminal.cs
//=================================================================
// PowerSDR is a C# implementation of a Software Defined Radio.
// Copyright (C) 2004-2012  FlexRadio Systems
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or(at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
//=================================================================

//
// Charly 25, HAMlab and STEMlab SDR Modifications Copyright (C) 2016 - 2021 Markus Grundner / DG8MG
//

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
