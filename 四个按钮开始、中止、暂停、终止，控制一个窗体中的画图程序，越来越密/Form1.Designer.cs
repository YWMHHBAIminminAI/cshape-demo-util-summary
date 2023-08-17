namespace WindowsFormsApp1
{
    partial class Form1
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
            this.startThreadButton = new System.Windows.Forms.Button();
            this.suspendThreadButton = new System.Windows.Forms.Button();
            this.resumeThreadButton = new System.Windows.Forms.Button();
            this.abortThreadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startThreadButton
            // 
            this.startThreadButton.Location = new System.Drawing.Point(-1, 48);
            this.startThreadButton.Name = "startThreadButton";
            this.startThreadButton.Size = new System.Drawing.Size(75, 23);
            this.startThreadButton.TabIndex = 0;
            this.startThreadButton.Text = "开始";
            this.startThreadButton.UseVisualStyleBackColor = true;
            this.startThreadButton.Click += new System.EventHandler(this.startThreadButton_Click);
            // 
            // suspendThreadButton
            // 
            this.suspendThreadButton.Enabled = false;
            this.suspendThreadButton.Location = new System.Drawing.Point(80, 48);
            this.suspendThreadButton.Name = "suspendThreadButton";
            this.suspendThreadButton.Size = new System.Drawing.Size(75, 23);
            this.suspendThreadButton.TabIndex = 1;
            this.suspendThreadButton.Text = "暂停";
            this.suspendThreadButton.UseVisualStyleBackColor = true;
            this.suspendThreadButton.Click += new System.EventHandler(this.suspendThreadButton_Click);
            // 
            // resumeThreadButton
            // 
            this.resumeThreadButton.Enabled = false;
            this.resumeThreadButton.Location = new System.Drawing.Point(161, 48);
            this.resumeThreadButton.Name = "resumeThreadButton";
            this.resumeThreadButton.Size = new System.Drawing.Size(75, 23);
            this.resumeThreadButton.TabIndex = 2;
            this.resumeThreadButton.Text = "恢复";
            this.resumeThreadButton.UseVisualStyleBackColor = true;
            this.resumeThreadButton.Click += new System.EventHandler(this.resumeThreadButton_Click);
            // 
            // abortThreadButton
            // 
            this.abortThreadButton.Enabled = false;
            this.abortThreadButton.Location = new System.Drawing.Point(242, 48);
            this.abortThreadButton.Name = "abortThreadButton";
            this.abortThreadButton.Size = new System.Drawing.Size(75, 23);
            this.abortThreadButton.TabIndex = 3;
            this.abortThreadButton.Text = "中止";
            this.abortThreadButton.UseVisualStyleBackColor = true;
            this.abortThreadButton.Click += new System.EventHandler(this.abortThreadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.abortThreadButton);
            this.Controls.Add(this.resumeThreadButton);
            this.Controls.Add(this.suspendThreadButton);
            this.Controls.Add(this.startThreadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startThreadButton;
        private System.Windows.Forms.Button suspendThreadButton;
        private System.Windows.Forms.Button resumeThreadButton;
        private System.Windows.Forms.Button abortThreadButton;
    }
}

