
namespace WindowsFormsCustomInfo
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
            this.lb_currentIndex = new System.Windows.Forms.Label();
            this.btn_nextstep = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_currentIndex
            // 
            this.lb_currentIndex.AutoSize = true;
            this.lb_currentIndex.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_currentIndex.ForeColor = System.Drawing.Color.Blue;
            this.lb_currentIndex.Location = new System.Drawing.Point(26, 19);
            this.lb_currentIndex.Name = "lb_currentIndex";
            this.lb_currentIndex.Size = new System.Drawing.Size(191, 36);
            this.lb_currentIndex.TabIndex = 1;
            this.lb_currentIndex.Text = "currentIndex";
            // 
            // btn_nextstep
            // 
            this.btn_nextstep.Location = new System.Drawing.Point(23, 306);
            this.btn_nextstep.Name = "btn_nextstep";
            this.btn_nextstep.Size = new System.Drawing.Size(754, 98);
            this.btn_nextstep.TabIndex = 3;
            this.btn_nextstep.Text = "下一步";
            this.btn_nextstep.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(23, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(754, 220);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_nextstep);
            this.Controls.Add(this.lb_currentIndex);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_currentIndex;
        private System.Windows.Forms.Button btn_nextstep;
        private System.Windows.Forms.ListBox listBox1;
    }
}

