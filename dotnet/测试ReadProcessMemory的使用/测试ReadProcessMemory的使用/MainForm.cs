using System;
using LynLib.Utils.Winform.LynForm;
using 测试ReadProcessMemory的使用.Others;

namespace 测试ReadProcessMemory的使用
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btn植物大战僵尸测试_Click(object sender, EventArgs e)
        {
            //阳光地址：[[007794f8 + 00000868] + 00005578]

            const int aBaseAddress = 0x007794f8; //基址
            const int aOffset1 = 0x00000868;//1级偏移量
            const int aOffset2 = 0x00005578;//2级偏移量
            const int aValue = 0x1869F;//0x1869F === 99999

            const string aProcessName = "PlantsVsZombies"; //进程名称

            var aAddress = Helper.ReadMemoryValue(aBaseAddress, aProcessName); //读取基址(该地址不会改变)

            aAddress = aAddress + aOffset1; //获取2级地址
            aAddress = Helper.ReadMemoryValue(aAddress, aProcessName);

            aAddress = aAddress + aOffset2; //获取3级地址（存放阳光数值的地址）

            Helper.WriteMemoryValue(aAddress, aValue, aProcessName);//写入要修改的值
        }

        private void btnDemoForTest测试_Click(object sender, EventArgs e)
        {

        }
    }
}