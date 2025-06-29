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
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(189, 37);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(837, 341);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // btnCalibrateVideo
            // 
            btnCalibrateVideo.Location = new Point(189, 405);
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
            Text = "灭火效能装置控制程序";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button btnCalibrateVideo;
    }
}
