namespace PowerSDR
{
    partial class C25SWRViewForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C25SWRViewForm));
            this.chrC25SWRView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrC25SWRView)).BeginInit();
            this.SuspendLayout();
            // 
            // chrC25SWRView
            // 
            this.chrC25SWRView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisX.Title = "Frequency (MHz)";
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.Title = "SWR";
            chartArea1.Name = "chaC25SWRView";
            this.chrC25SWRView.ChartAreas.Add(chartArea1);
            this.chrC25SWRView.Location = new System.Drawing.Point(12, 12);
            this.chrC25SWRView.Name = "chrC25SWRView";
            series1.ChartArea = "chaC25SWRView";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "serSWRData";
            this.chrC25SWRView.Series.Add(series1);
            this.chrC25SWRView.Size = new System.Drawing.Size(660, 438);
            this.chrC25SWRView.TabIndex = 0;
            // 
            // C25SWRViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.chrC25SWRView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "C25SWRViewForm";
            this.Text = "TX Frequency Sweep Test - SWR View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.C25SWRViewForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chrC25SWRView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrC25SWRView;
    }
}