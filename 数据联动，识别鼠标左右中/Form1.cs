using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms0803
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button1.Click += new EventHandler(button1_Click);
            button1.Click += (s, e) =>
             {
                 button1_Click(s, e);
             };

            //button1.Click += (s, e) => button2_Click(s.GetType().Name);
            //label1.Click += (s, e) => button2_Click(s.GetType().Name);
            MyEventNotify.BtnTextEvent += IfIRecvButtonText;

            button1.MouseDown += Button1_MouseDown;
        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {

            MyEventNotify.NotifyBtnText($"我点击的按钮名：{(sender as Button).Text},点击的鼠标键位是：{e.Button}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("111");
        }

        private void button2_Click(string controlType)
        {
            switch(controlType)
            {
                case "Button":
                    MessageBox.Show("你点击了一个按钮");
                    break;
                case "Label":
                    MessageBox.Show("你点击了一个标签");
                    break;
            }
        }

        private void IfIRecvButtonText(string btnText)
        {
            label1.Text = btnText;
        }
    }


    public static class MyEventNotify
    {
        public static event MyBtnTextDelegate BtnTextEvent;

        public static void NotifyBtnText(string btnText)
        {
            //if(BtnTextEvent != null)
            //{
            //    BtnTextEvent(btnText);
            //}

            // =>

            BtnTextEvent?.Invoke(btnText);
        }
    }


    public delegate void MyBtnTextDelegate(string btnText);
}
