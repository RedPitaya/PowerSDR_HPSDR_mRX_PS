//
// Charly 25, HAMlab and STEMlab SDR Modifications Copyright (C) 2016, 2017 Markus Grundner / DG8MG
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PowerSDR
{
    public partial class RPDeviceForm : Form
    {
        public RPDeviceForm()
        {
            InitializeComponent();
        }

        private void btnChooseDeviceOK_Click(object sender, EventArgs e)
        {
            if (lbChooseDevice.SelectedIndex > -1)
            {
                DialogResult = DialogResult.OK;
                Close();   
            }         
        }

        private void btnChooseDeviceCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();           
        }
    }
}
