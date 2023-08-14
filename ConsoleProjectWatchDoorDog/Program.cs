using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinFormWatchDogAlarm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //我的看门狗小黑
            WatchDoorDog watchDoorDogSmallBlack = new WatchDoorDog();

            //我的家
            MyHome myHome = new MyHome(watchDoorDogSmallBlack);

            DateTime now = new DateTime(2008, 12, 31, 23, 59, 59);
            DateTime midnight = new DateTime(2009, 1, 1, 0, 0, 6);

            Console.WriteLine("时间一秒一秒的流逝");
            while(now < midnight)
            {
                Console.WriteLine("当前时间：" + now);
                System.Threading.Thread.Sleep(1000);
                now = now.AddSeconds(1);
            }

            Console.WriteLine("\n月黑风高的午夜：" + now);
            Console.WriteLine("小偷悄悄摸进了主人屋内...");
            //Console.ReadLine();
            //WatchDoorDog调用OnAlarm()函数，从而触发AlarmEventHandler事件
            watchDoorDogSmallBlack.OnAlarm();

        }
    }
}
