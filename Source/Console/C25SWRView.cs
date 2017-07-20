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
            chrC25SWRView.ChartAreas[0].AxisY.Maximum = 10.0;
            chrC25SWRView.Series["serSWRData"].Points.Clear();
        }

        public void c25SWRViewChartPrintData(double frequency, float swr)
        {                       
            chrC25SWRView.Series["serSWRData"].Points.AddXY(frequency, swr);
        }

        private void C25SWRViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Setup.C25SWRView = null;
        }
    }
}
