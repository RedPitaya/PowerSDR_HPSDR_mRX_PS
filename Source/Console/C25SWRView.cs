//=================================================================
// C25SWRView.cs
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
// Charly 25, HAMlab and STEMlab SDR Modifications Copyright (C) 2016 - 2019 Markus Grundner / DG8MG
//

using System.Windows.Forms;

namespace PowerSDR
{
    public partial class C25SWRViewForm : Form
    {
        public C25SWRViewForm(Setup setup)
        {
            InitializeComponent();
        }

        public void c25SWRViewChartSetup(Setup setup)
        {           
            chrC25SWRView.ChartAreas[0].AxisX.Minimum = (double)setup.udC25TXFreqSwpTestStartFrequency.Value / 1e6;
            chrC25SWRView.ChartAreas[0].AxisX.Maximum = (double)setup.udC25TXFreqSwpTestStopFrequency.Value / 1e6;
            chrC25SWRView.ChartAreas[0].AxisY.Minimum = 1.0;
            chrC25SWRView.ChartAreas[0].AxisY.Maximum = 5.0;
            chrC25SWRView.Series["serSWRData"].Points.Clear();
        }

        public void c25SWRViewChartPrintData(double frequency, float swr)
        {                       
            chrC25SWRView.Series["serSWRData"].Points.AddXY(frequency, swr);
        }

        private void C25SWRViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.getConsole().SetupForm.btnC25TXFreqSwpTestCSVExport.Enabled = false;
            Setup.C25SWRView = null;
        }
    }
}
