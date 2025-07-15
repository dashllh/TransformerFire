namespace TransformerFireApp
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnCalibrateVideo = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.Position;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.None;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.Interval = 60D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.LabelStyle.ForeColor = Color.Gray;
            chartArea1.AxisX.LineColor = Color.LightGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea1.AxisX.MajorTickMark.LineColor = Color.Gray;
            chartArea1.AxisX.Maximum = 300D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorTickMark.LineColor = Color.Gray;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelStyle.ForeColor = Color.Gray;
            chartArea1.AxisY.LineColor = Color.Transparent;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea1.AxisY.MajorTickMark.LineColor = Color.LightGray;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.LineColor = Color.LightGray;
            chartArea1.AxisY.MinorTickMark.LineColor = Color.LightGray;
            chartArea1.AxisY.Title = "油温(℃)";
            chartArea1.AxisY.TitleFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            chartArea1.AxisY.TitleForeColor = Color.Gray;
            chartArea1.BackColor = Color.Black;
            chartArea1.BorderColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = Color.Transparent;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.ForeColor = Color.Gray;
            legend1.Name = "legendOilTemp";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            legend1.TitleForeColor = Color.Transparent;
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(214, 28);
            chart1.Name = "chart1";
            series1.BorderColor = Color.Transparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = Color.Firebrick;
            series1.Legend = "legendOilTemp";
            series1.LegendText = "油温";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chart1.Series.Add(series1);
            chart1.Size = new Size(876, 348);
            chart1.TabIndex = 17;
            chart1.Text = "chart1";
            // 
            // btnCalibrateVideo
            // 
            btnCalibrateVideo.Location = new Point(214, 407);
            btnCalibrateVideo.Name = "btnCalibrateVideo";
            btnCalibrateVideo.Size = new Size(142, 50);
            btnCalibrateVideo.TabIndex = 1;
            btnCalibrateVideo.Text = "校准摄像头";
            btnCalibrateVideo.UseVisualStyleBackColor = true;
            btnCalibrateVideo.Click += btnCalibrateVideo_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 504);
            Controls.Add(btnCalibrateVideo);
            Controls.Add(chart1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "灭火效能装置控制程序";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button btnCalibrateVideo;
    }
}
