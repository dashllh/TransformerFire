namespace TransformerFireApp.Forms
{
    public partial class DistInputForm : Form
    {
        public float PhysicalDistance { get; private set; } = 0.0f;
        public DistInputForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 验证输入的物理距离是否为有效数字
            if (float.TryParse(txtDistance.Text, out float dist) && dist > 0)
            {
                PhysicalDistance = dist;
                // 设置对话框结果为OK
                DialogResult = DialogResult.OK;
                // 关闭对话框
                Close(); 
            }
            else
            {
                MessageBox.Show("输入有误,请输入有效的物理距离！", "系统消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
