namespace 测试ReadProcessMemory的使用
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
            this.btn植物大战僵尸测试 = new System.Windows.Forms.Button();
            this.btnDemoForTest测试 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn植物大战僵尸测试
            // 
            this.btn植物大战僵尸测试.Location = new System.Drawing.Point(51, 28);
            this.btn植物大战僵尸测试.Name = "btn植物大战僵尸测试";
            this.btn植物大战僵尸测试.Size = new System.Drawing.Size(110, 23);
            this.btn植物大战僵尸测试.TabIndex = 1;
            this.btn植物大战僵尸测试.Text = "植物大战僵尸测试";
            this.btn植物大战僵尸测试.UseVisualStyleBackColor = true;
            this.btn植物大战僵尸测试.Click += new System.EventHandler(this.btn植物大战僵尸测试_Click);
            // 
            // btnDemoForTest测试
            // 
            this.btnDemoForTest测试.Location = new System.Drawing.Point(51, 73);
            this.btnDemoForTest测试.Name = "btnDemoForTest测试";
            this.btnDemoForTest测试.Size = new System.Drawing.Size(110, 23);
            this.btnDemoForTest测试.TabIndex = 1;
            this.btnDemoForTest测试.Text = "DemoForTest测试";
            this.btnDemoForTest测试.UseVisualStyleBackColor = true;
            this.btnDemoForTest测试.Click += new System.EventHandler(this.btnDemoForTest测试_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 125);
            this.Controls.Add(this.btnDemoForTest测试);
            this.Controls.Add(this.btn植物大战僵尸测试);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn植物大战僵尸测试;
        private System.Windows.Forms.Button btnDemoForTest测试;
    }
}

