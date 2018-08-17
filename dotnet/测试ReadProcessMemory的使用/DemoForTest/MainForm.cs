using System;
using System.Windows.Forms;
using LynLib.Utils.Common;
using LynLib.Utils.Winform.LynForm;

namespace DemoForTest
{
    public partial class MainForm : BaseForm
    {
        public int ValueForReadProcessMemory = 1212;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ValueForReadProcessMemory.ToString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            ValueForReadProcessMemory = TypeConvertHelper.ToInt(txtSet.Text);
        }
    }
}