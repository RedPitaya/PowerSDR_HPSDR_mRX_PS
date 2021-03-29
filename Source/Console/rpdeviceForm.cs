//=================================================================
// rpdeviceForm.cs
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

        private void lbChooseDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbChooseDevice.SelectedIndex > -1)
            {
                btnChooseDeviceOK.Enabled = true;
            }
            else
            {
                btnChooseDeviceOK.Enabled = false;
            }
        }
    }
}
