using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using cwber;

namespace 测试ChromeWebBrowser.net
{
    public partial class MainForm : Form
    {
        private ChromeWebBrowser chromeWebBrowser2;

        public MainForm()
        {
            InitializeComponent();
            chromeWebBrowser2 = AddBrowser();
            tabPage1.Controls.Add(chromeWebBrowser2);
            chromeWebBrowser2.SetBounds(0, 0, tabPage1.Width, tabPage1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chromeWebBrowser2.OpenUrl(textBox1.Text);
        }

        private void componentInit(object sender, EventArgs e)
        {
            chromeWebBrowser2.SetCookiePath("C:\\");
            MessageBox.Show("初始化完成.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chromeWebBrowser2.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chromeWebBrowser2.GoBack();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //chromeWebBrowser2.ExecuteScript("alert('123');");
            chromeWebBrowser2.ExecuteScript("alert(document.getElementById('kw'));");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //open www.baidu.com
            var value = chromeWebBrowser2.GetElementValueById("kw");
            MessageBox.Show(value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //open www.baidu.com
            chromeWebBrowser2.SetElementValueById("kw", "ChromeWebBrowser for .net");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //open www.baidu.com
            chromeWebBrowser2.AppendElementEventListener("su", "click", new ChromeWebBrowser.TCallBackElementEventListener(ShowMsg));
        }

        public void ShowMsg()
        {
            MessageBox.Show("click event");
        }

        public int ShowMessage(string message)
        {
            MessageBox.Show(message.ToString());
            return 101;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            chromeWebBrowser2.Free();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //binding myval into window.
            var htmltext2 = "<script language=\"JavaScript\">alert('11');</script>";
            chromeWebBrowser2.LoadHtml(htmltext2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show(chromeWebBrowser2.UserAgent);
        }

        private ChromeWebBrowser AddBrowser()
        {
            var settings = new CSharpBrowserSettings();
            settings.CachePath = "D:\\temp\\caches";
            settings.Locale = "zh-cn";
            settings.LocalesDirPath = "F:\\DotNet\\ChromeTest\\ChromeTest\\bin\\Debug\\locales";
            settings.UserAgent = "Mozilla/5.0 ChromeTest v1.01";
            var browser = new ChromeWebBrowser(settings);
            browser.newWindowEventHandler += new NewWindowEventHandler(browserNewWindowEvent);
            browser.DocumentCompletedEventHandler += new EventHandler(documentCompleteEvent);
            browser.Location = new Point(0, 0);
            browser.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                | AnchorStyles.Left)
                                               | AnchorStyles.Right)));

            return browser;
        }

        private void NewPage(string newUrl)
        {
            var newPage = new TabPage(newUrl);
            tabControl1.TabPages.Add(newPage);
            tabControl1.SelectTab(newPage);

            var browser = AddBrowser();
            newPage.Controls.Add(browser);
            browser.Validate();
            browser.SetBounds(0, 0, newPage.Width, newPage.Height);
            //open new url
            var t = new Thread(new ParameterizedThreadStart(OpenWebsite));
            t.Start(new NewPageObject(browser, newUrl));
        }


        private void OpenWebsite(object o)
        {
            var pageObject = o as NewPageObject;
            pageObject.Browser.OpenUrl(pageObject.Url);
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            var b = ((Button) sender).Parent.Controls[1] as ChromeWebBrowser;
            b.OpenUrl((((Button) sender).Parent as TabPage).Text);
        }

        private void documentCompleteEvent(object sender, EventArgs e)
        {
            ((TabPage) ((Control) sender).Parent).Text = ((ChromeWebBrowser) sender).Title;
        }

        private void browserNewWindowEvent(object sender, NewWindowEventArgs e)
        {
            if (InvokeRequired)
            {
                var a = new NewPageListener(NewPage);
                Invoke(a, new object[] {e.NewUrl});
            }
            else
            {
                NewPage(e.NewUrl);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var newPage = new TabPage("http://www.google.com");
            tabControl1.TabPages.Add(newPage);
            tabControl1.SelectTab(newPage);
            var browser = AddBrowser();
            newPage.Controls.Add(browser);
            browser.Validate();
            browser.SetBounds(0, 0, newPage.Width, newPage.Height);
            browser.OpenUrl("http://www.google.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //open home page
            chromeWebBrowser2.OpenUrl("http://www.google.com");
        }

        private delegate void NewPageListener(string url);
    }

    internal class NewPageObject
    {
        public ChromeWebBrowser Browser;
        public string Url;

        public NewPageObject(ChromeWebBrowser cwber, string url)
        {
            Browser = cwber;
            Url = url;
        }
    }
}