namespace TransformerFireApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalibrateVideo_Click(object sender, EventArgs e)
        {
            var videoCalibrateForm = new VideoCalibrateForm();
            videoCalibrateForm.ShowDialog();
        }
    }
}
