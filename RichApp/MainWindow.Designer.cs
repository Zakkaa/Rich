namespace RichApp
{
    partial class MainWindow
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPageHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // MainPageHost
            // 
            this.MainPageHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageHost.Location = new System.Drawing.Point(0, 0);
            this.MainPageHost.Name = "MainPageHost";
            this.MainPageHost.Size = new System.Drawing.Size(800, 450);
            this.MainPageHost.TabIndex = 0;
            this.MainPageHost.Text = "elementHost1";
            this.MainPageHost.Child = null;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPageHost);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost MainPageHost;
    }
}

