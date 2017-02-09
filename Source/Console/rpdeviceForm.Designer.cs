namespace PowerSDR
{
    partial class RPDeviceForm
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
            this.lbChooseDevice = new System.Windows.Forms.ListBox();
            this.lblChooseDevice = new System.Windows.Forms.Label();
            this.btnChooseDeviceOK = new System.Windows.Forms.Button();
            this.btnChooseDeviceCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbChooseDevice
            // 
            this.lbChooseDevice.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChooseDevice.FormattingEnabled = true;
            this.lbChooseDevice.ItemHeight = 14;
            this.lbChooseDevice.Location = new System.Drawing.Point(15, 66);
            this.lbChooseDevice.Name = "lbChooseDevice";
            this.lbChooseDevice.Size = new System.Drawing.Size(567, 88);
            this.lbChooseDevice.Sorted = true;
            this.lbChooseDevice.TabIndex = 0;
            // 
            // lblChooseDevice
            // 
            this.lblChooseDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChooseDevice.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseDevice.Location = new System.Drawing.Point(15, 9);
            this.lblChooseDevice.Name = "lblChooseDevice";
            this.lblChooseDevice.Size = new System.Drawing.Size(567, 54);
            this.lblChooseDevice.TabIndex = 1;
            this.lblChooseDevice.Text = "There seems to be more than one Charly 25 / HAMlab device active in your network " +
    "environment!\r\nPlease choose the device you want to start up.\r\n";
            this.lblChooseDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChooseDeviceOK
            // 
            this.btnChooseDeviceOK.Location = new System.Drawing.Point(15, 187);
            this.btnChooseDeviceOK.Name = "btnChooseDeviceOK";
            this.btnChooseDeviceOK.Size = new System.Drawing.Size(75, 23);
            this.btnChooseDeviceOK.TabIndex = 2;
            this.btnChooseDeviceOK.Text = "OK";
            this.btnChooseDeviceOK.UseVisualStyleBackColor = true;
            this.btnChooseDeviceOK.Click += new System.EventHandler(this.btnChooseDeviceOK_Click);
            // 
            // btnChooseDeviceCancel
            // 
            this.btnChooseDeviceCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChooseDeviceCancel.Location = new System.Drawing.Point(507, 187);
            this.btnChooseDeviceCancel.Name = "btnChooseDeviceCancel";
            this.btnChooseDeviceCancel.Size = new System.Drawing.Size(75, 23);
            this.btnChooseDeviceCancel.TabIndex = 3;
            this.btnChooseDeviceCancel.Text = "Cancel";
            this.btnChooseDeviceCancel.UseVisualStyleBackColor = true;
            this.btnChooseDeviceCancel.Click += new System.EventHandler(this.btnChooseDeviceCancel_Click);
            // 
            // RPDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 222);
            this.ControlBox = false;
            this.Controls.Add(this.btnChooseDeviceCancel);
            this.Controls.Add(this.btnChooseDeviceOK);
            this.Controls.Add(this.lblChooseDevice);
            this.Controls.Add(this.lbChooseDevice);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RPDeviceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose device to start up";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lbChooseDevice;
        private System.Windows.Forms.Label lblChooseDevice;
        private System.Windows.Forms.Button btnChooseDeviceOK;
        private System.Windows.Forms.Button btnChooseDeviceCancel;
    }
}