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
            ((System.ComponentModel.ISupportInitialize)picOrigin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picThreshHold).BeginInit();
            SuspendLayout();
            // 
            // picOrigin
            // 
            picOrigin.Location = new Point(12, 12);
            picOrigin.Name = "picOrigin";
            picOrigin.Size = new Size(349, 286);
            picOrigin.TabIndex = 0;
            picOrigin.TabStop = false;
            // 
            // picThreshHold
            // 
            picThreshHold.Location = new Point(383, 12);
            picThreshHold.Name = "picThreshHold";
            picThreshHold.Size = new Size(351, 285);
            picThreshHold.TabIndex = 1;
            picThreshHold.TabStop = false;
            // 
            // btnOpenVideo
            // 
            btnOpenVideo.Location = new Point(797, 12);
            btnOpenVideo.Name = "btnOpenVideo";
            btnOpenVideo.Size = new Size(141, 45);
            btnOpenVideo.TabIndex = 3;
            btnOpenVideo.Text = "打开摄像头";
            btnOpenVideo.UseVisualStyleBackColor = true;
            btnOpenVideo.Click += btnOpenVideo_Click;
            // 
            // btnCloseVideo
            // 
            btnCloseVideo.Location = new Point(798, 81);
            btnCloseVideo.Name = "btnCloseVideo";
            btnCloseVideo.Size = new Size(139, 45);
            btnCloseVideo.TabIndex = 5;
            btnCloseVideo.Text = "关闭摄像头";
            btnCloseVideo.UseVisualStyleBackColor = true;
            btnCloseVideo.Click += btnCloseVideo_Click;
            // 
            // VideoCalibrateForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 450);
            Controls.Add(btnCloseVideo);
            Controls.Add(btnOpenVideo);
            Controls.Add(picThreshHold);
            Controls.Add(picOrigin);
            Name = "VideoCalibrateForm";
            Text = "VideoCalibrateForm";
            ((System.ComponentModel.ISupportInitialize)picOrigin).EndInit();
            ((System.ComponentModel.ISupportInitialize)picThreshHold).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picOrigin;
        private PictureBox picThreshHold;
        private Button btnOpenVideo;
        private Button btnCloseVideo;
    }
}