using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormWatchDogAlarm
{
    /// <summary>
    /// 这就是我被看门狗看的家
    /// </summary>
    class MyHome
    {
        // 4.编写事件处理程序
        void HomeAlarmHandler(object sender, EventArgs e)
        {
            Console.WriteLine("主 人 ： 抓住了小偷！");
            Console.ReadLine();
        }

        //5.注册事件处理程序
        public MyHome(WatchDoorDog watchDoorDog)
        {
            watchDoorDog.AlarmEvent += new WatchDoorDog.AlarmEventHandler(HomeAlarmHandler);
        }
    }
}
