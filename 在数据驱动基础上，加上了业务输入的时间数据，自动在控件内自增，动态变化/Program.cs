using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();

            form.InitData(new MyData
            {
                Name = "aaa",
                Descriptions = "我的描述"
            });

            form.UpdateData("Name", "张三");

            timer.Interval = 1000;
            var index = 0;
            timer.Tick += (s, e) =>
            {
                var key = index % 2 == 0 ? "Name" : "Desc";
                form.UpdateData(key, index.ToString());
                index++;
            };
            timer.Start();


            Application.Run(form);
        }

        static Timer timer = new Timer();
    }
}
