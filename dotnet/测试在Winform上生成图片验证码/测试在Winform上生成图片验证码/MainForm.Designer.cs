namespace 测试在Winform上生成图片验证码
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTest = new System.Windows.Forms.Button();
            this.lbl请输入验证码 = new System.Windows.Forms.Label();
            this.txt验证码 = new System.Windows.Forms.TextBox();
            this.pb验证码 = new System.Windows.Forms.PictureBox();
            this.btnReCreateImg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb验证码)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(111, 119);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lbl请输入验证码
            // 
            this.lbl请输入验证码.AutoSize = true;
            this.lbl请输入验证码.Location = new System.Drawing.Point(22, 15);
            this.lbl请输入验证码.Name = "lbl请输入验证码";
            this.lbl请输入验证码.Size = new System.Drawing.Size(77, 12);
            this.lbl请输入验证码.TabIndex = 0;
            this.lbl请输入验证码.Text = "请输入验证码";
            // 
            // txt验证码
            // 
            this.txt验证码.Location = new System.Drawing.Point(111, 11);
            this.txt验证码.Name = "txt验证码";
            this.txt验证码.Size = new System.Drawing.Size(100, 21);
            this.txt验证码.TabIndex = 1;
            // 
            // pb验证码
            // 
            this.pb验证码.Location = new System.Drawing.Point(22, 48);
            this.pb验证码.Name = "pb验证码";
            this.pb验证码.Size = new System.Drawing.Size(200, 50);
            this.pb验证码.TabIndex = 4;
            this.pb验证码.TabStop = false;
            // 
            // btnReCreateImg
            // 
            this.btnReCreateImg.Location = new System.Drawing.Point(22, 119);
            this.btnReCreateImg.Name = "btnReCreateImg";
            this.btnReCreateImg.Size = new System.Drawing.Size(75, 23);
            this.btnReCreateImg.TabIndex = 2;
            this.btnReCreateImg.Text = "换一张";
            this.btnReCreateImg.UseVisualStyleBackColor = true;
            this.btnReCreateImg.Click += new System.EventHandler(this.btnReCreateImg_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 152);
            this.Controls.Add(this.btnReCreateImg);
            this.Controls.Add(this.pb验证码);
            this.Controls.Add(this.txt验证码);
            this.Controls.Add(this.lbl请输入验证码);
            this.Controls.Add(this.btnTest);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb验证码)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lbl请输入验证码;
        private System.Windows.Forms.TextBox txt验证码;
        private System.Windows.Forms.PictureBox pb验证码;
        private System.Windows.Forms.Button btnReCreateImg;
    }
}

