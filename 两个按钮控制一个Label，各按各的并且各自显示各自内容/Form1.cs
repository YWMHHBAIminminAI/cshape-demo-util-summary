using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTwoButtonEventDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在Form类中创建一个名为Button_Click的事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            if(((Button)sender).Name == "buttonOne")
            {
                messageLabel.Text = "信息：Button One was Clicked";
            }
            else
            {
                messageLabel.Text = "信息：Button Two was Clicked";
            }
            
        }
    }
}
