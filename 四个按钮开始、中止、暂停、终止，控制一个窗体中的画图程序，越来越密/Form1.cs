using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region Form1构造函数
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region 图形绘制函数
        /// <summary>
        /// 第一步：创建线程的入口函数
        /// </summary>
        private void DrawGraph()
        {
            int loop = 0;
            int sect = 0;
            float[] x = new float[31];
            float[] y = new float[31];

            //绘制图形10000遍，每隔200毫秒绘制一遍
            while (loop <= 10000)
            {
                sect = (sect + 1) % 25 + 1;

                //绘制图形
                Graphics graphics = this.CreateGraphics();
                for (int i = 0; i < sect; i++)
                {
                    x[i] = ((float)(150 * Math.Cos(i * 2 * Math.PI / sect) + 150));
                    y[i] = (float)(150 * Math.Sin(i * 2 * Math.PI / sect) + 150);
                }
                for (int m = 0; m < sect - 1; m++)
                {
                    for (int n = 0; n < sect; n++)
                    {
                        graphics.DrawLine(Pens.Blue, x[m], y[m], x[n], y[n]);
                    }
                }

                //线程暂停200ms
                Thread.Sleep(200);

                //清除图形，以便重新绘制
                graphics.Clear(this.BackColor);
                loop++;
            }
        }
        #endregion

        #region 声明工作线程，并创建四个按钮的事件
        /// <summary>
        /// 声明工作线程
        /// </summary>
        Thread DrawGraphThread;

        /// <summary>
        /// 开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startThreadButton_Click(object sender, EventArgs e)
        {
            //第二步：创建入口委托
            ThreadStart entryPoint = new ThreadStart(DrawGraph);

            ////第三步：创建线程，并启动线程
            //new Thread(entryPoint).Start();

            //第三步：创建线程
            DrawGraphThread = new Thread(entryPoint);

            //启动线程
            DrawGraphThread.Start();

            //设置按钮的有效性
            startThreadButton.Enabled = false;
            suspendThreadButton.Enabled = true;
            resumeThreadButton.Enabled = false;
            abortThreadButton.Enabled = true;
        }

        /// <summary>
        /// 暂停按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suspendThreadButton_Click(object sender, EventArgs e)
        {
            //暂停线程。Suspend()和Abort()方法并不是立即停止线程，对于Suspend()方法，.NET会让线程再继续执行几个指令以确保线程在安全状态下挂起
            DrawGraphThread.Suspend();

            //设置按钮的有效性
            suspendThreadButton.Enabled = false;
            resumeThreadButton.Enabled = true;
            abortThreadButton.Enabled = false;

        }

        /// <summary>
        /// 恢复按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resumeThreadButton_Click(object sender, EventArgs e)
        {
            //恢复线程
            DrawGraphThread.Resume();

            //设置按钮的有效性
            resumeThreadButton.Enabled = false;
            suspendThreadButton.Enabled = true;
            abortThreadButton.Enabled = true;
        }

        /// <summary>
        /// 中止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abortThreadButton_Click(object sender, EventArgs e)
        {
            // 中止线程.Suspend()和Abort()方法并不是立即停止线程，对于Suspend()方法，.NET会让线程再继续执行几个指令以确保线程在安全状态下挂起
            //中止线程时Abort()方法会抛出一个ThreadAbortException异常，可以保证线程中止时如果正在执行try语句的代码，可以确保对应finally块被执行，然后确保相应资源被释放
            DrawGraphThread.Abort();

            //设置按钮的有效性
            startThreadButton.Enabled = true;
            suspendThreadButton.Enabled = false;
            resumeThreadButton.Enabled = false;
            abortThreadButton.Enabled = false;
        }
        #endregion
    }
}
