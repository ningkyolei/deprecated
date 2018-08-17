using System;
using System.Windows.Forms;
using LynLib.Utils.Winform.LynForm;

namespace 测试在Winform上生成图片验证码
{
    public partial class MainForm : BaseForm
    {
        private readonly ImageValidationCodeHelper _Helper;

        public MainForm()
        {
            InitializeComponent();

            var aParameter = new ImageValidationCodeHelper.Parameter();
            _Helper = new ImageValidationCodeHelper(aParameter);

            //_Helper = new ImageValidationCodeHelper();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var aText = txt验证码.Text.Trim();
            var aFlag = _Helper.Validate(aText);
            if (aFlag)
            {
                MessageBox.Show("验证码输入正确！");
            }
            else
            {
                MessageBox.Show("验证码输入错误！");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pb验证码.Image = _Helper.CreateImage();
        }

        private void btnReCreateImg_Click(object sender, EventArgs e)
        {
            pb验证码.Image = _Helper.CreateImage();
        }
    }
}