namespace TransformerFireApp
{
    partial class VideoCalibrateForm
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
            picOrigin = new PictureBox();
            picThreshHold = new PictureBox();
            btnOpenVideo = new Button();
            btnCloseVideo = new Button();
            groupBox1 = new GroupBox();
            rdoFireArea = new RadioButton();
            rdoDistIndex = new RadioButton();
            groupBox2 = new GroupBox();
            lblDistIndex = new Label();
            btnCheckResult = new Button();
            btnCloseForm = new Button();
            ((System.ComponentModel.ISupportInitialize)picOrigin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picThreshHold).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // picOrigin
            // 
            picOrigin.BorderStyle = BorderStyle.FixedSingle;
            picOrigin.Location = new Point(12, 12);
            picOrigin.Name = "picOrigin";
            picOrigin.Size = new Size(640, 480);
            picOrigin.TabIndex = 0;
            picOrigin.TabStop = false;
            picOrigin.Paint += picOrigin_Paint;
            picOrigin.MouseClick += picOrigin_MouseClick;
            picOrigin.MouseMove += picOrigin_MouseMove;
            // 
            // picThreshHold
            // 
            picThreshHold.BorderStyle = BorderStyle.FixedSingle;
            picThreshHold.Location = new Point(671, 12);
            picThreshHold.Name = "picThreshHold";
            picThreshHold.Size = new Size(640, 480);
            picThreshHold.TabIndex = 1;
            picThreshHold.TabStop = false;
            // 
            // btnOpenVideo
            // 
            btnOpenVideo.Location = new Point(671, 529);
            btnOpenVideo.Name = "btnOpenVideo";
            btnOpenVideo.Size = new Size(140, 45);
            btnOpenVideo.TabIndex = 3;
            btnOpenVideo.Text = "打开摄像头";
            btnOpenVideo.UseVisualStyleBackColor = true;
            btnOpenVideo.Click += btnOpenVideo_Click;
            // 
            // btnCloseVideo
            // 
            btnCloseVideo.Enabled = false;
            btnCloseVideo.Location = new Point(1005, 529);
            btnCloseVideo.Name = "btnCloseVideo";
            btnCloseVideo.Size = new Size(140, 45);
            btnCloseVideo.TabIndex = 5;
            btnCloseVideo.Text = "关闭摄像头";
            btnCloseVideo.UseVisualStyleBackColor = true;
            btnCloseVideo.Click += btnCloseVideo_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdoFireArea);
            groupBox1.Controls.Add(rdoDistIndex);
            groupBox1.Location = new Point(12, 503);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(349, 84);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "标定选项";
            // 
            // rdoFireArea
            // 
            rdoFireArea.AutoSize = true;
            rdoFireArea.Location = new Point(188, 35);
            rdoFireArea.Name = "rdoFireArea";
            rdoFireArea.Size = new Size(90, 24);
            rdoFireArea.TabIndex = 1;
            rdoFireArea.TabStop = true;
            rdoFireArea.Text = "火焰区域";
            rdoFireArea.UseVisualStyleBackColor = true;
            rdoFireArea.CheckedChanged += rdoFireArea_CheckedChanged;
            // 
            // rdoDistIndex
            // 
            rdoDistIndex.AutoSize = true;
            rdoDistIndex.Checked = true;
            rdoDistIndex.Location = new Point(34, 35);
            rdoDistIndex.Name = "rdoDistIndex";
            rdoDistIndex.Size = new Size(90, 24);
            rdoDistIndex.TabIndex = 0;
            rdoDistIndex.TabStop = true;
            rdoDistIndex.Text = "距离系数";
            rdoDistIndex.UseVisualStyleBackColor = true;
            rdoDistIndex.CheckedChanged += rdoDistIndex_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblDistIndex);
            groupBox2.Location = new Point(383, 503);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(168, 84);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "距离系数";
            // 
            // lblDistIndex
            // 
            lblDistIndex.BackColor = Color.Black;
            lblDistIndex.Dock = DockStyle.Fill;
            lblDistIndex.FlatStyle = FlatStyle.Flat;
            lblDistIndex.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDistIndex.ForeColor = Color.FromArgb(255, 255, 15);
            lblDistIndex.Location = new Point(3, 23);
            lblDistIndex.Name = "lblDistIndex";
            lblDistIndex.Size = new Size(162, 58);
            lblDistIndex.TabIndex = 0;
            lblDistIndex.Text = "8888";
            lblDistIndex.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCheckResult
            // 
            btnCheckResult.Enabled = false;
            btnCheckResult.Location = new Point(838, 529);
            btnCheckResult.Name = "btnCheckResult";
            btnCheckResult.Size = new Size(140, 45);
            btnCheckResult.TabIndex = 8;
            btnCheckResult.Text = "开始测量";
            btnCheckResult.UseVisualStyleBackColor = true;
            btnCheckResult.Click += btnCheckResult_Click;
            // 
            // btnCloseForm
            // 
            btnCloseForm.Location = new Point(1171, 529);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(140, 45);
            btnCloseForm.TabIndex = 9;
            btnCloseForm.Text = "退出";
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // VideoCalibrateForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 604);
            Controls.Add(btnCloseForm);
            Controls.Add(btnCheckResult);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnCloseVideo);
            Controls.Add(btnOpenVideo);
            Controls.Add(picThreshHold);
            Controls.Add(picOrigin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "VideoCalibrateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "摄像头校准";
            Load += VideoCalibrateForm_Load;
            ((System.ComponentModel.ISupportInitialize)picOrigin).EndInit();
            ((System.ComponentModel.ISupportInitialize)picThreshHold).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picOrigin;
        private PictureBox picThreshHold;
        private Button btnOpenVideo;
        private Button btnCloseVideo;
        private GroupBox groupBox1;
        private RadioButton rdoFireArea;
        private RadioButton rdoDistIndex;
        private GroupBox groupBox2;
        private Label lblDistIndex;
        private Button btnCheckResult;
        private Button btnCloseForm;
    }
}