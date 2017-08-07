namespace PowerSDR
{
    partial class C25SSHTerminalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C25SSHTerminalForm));
            this.tbC25SSHTerminalOutput = new System.Windows.Forms.TextBoxTS();
            this.tbC25SSHTerminalInput = new System.Windows.Forms.TextBoxTS();
            this.SuspendLayout();
            // 
            // tbC25SSHTerminalOutput
            // 
            this.tbC25SSHTerminalOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbC25SSHTerminalOutput.BackColor = System.Drawing.SystemColors.Window;
            this.tbC25SSHTerminalOutput.Location = new System.Drawing.Point(13, 13);
            this.tbC25SSHTerminalOutput.Multiline = true;
            this.tbC25SSHTerminalOutput.Name = "tbC25SSHTerminalOutput";
            this.tbC25SSHTerminalOutput.ReadOnly = true;
            this.tbC25SSHTerminalOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbC25SSHTerminalOutput.Size = new System.Drawing.Size(599, 391);
            this.tbC25SSHTerminalOutput.TabIndex = 1;
            // 
            // tbC25SSHTerminalInput
            // 
            this.tbC25SSHTerminalInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbC25SSHTerminalInput.Location = new System.Drawing.Point(12, 410);
            this.tbC25SSHTerminalInput.Name = "tbC25SSHTerminalInput";
            this.tbC25SSHTerminalInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbC25SSHTerminalInput.Size = new System.Drawing.Size(600, 20);
            this.tbC25SSHTerminalInput.TabIndex = 0;
            this.tbC25SSHTerminalInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbC25SSHTerminalInput_KeyPress);
            // 
            // C25SSHTerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.tbC25SSHTerminalInput);
            this.Controls.Add(this.tbC25SSHTerminalOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "C25SSHTerminalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSH Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.C25SSHTerminalForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBoxTS tbC25SSHTerminalOutput;
        public System.Windows.Forms.TextBoxTS tbC25SSHTerminalInput;
    }
}