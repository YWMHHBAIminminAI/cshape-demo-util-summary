using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormWatchDogAlarm
{
    /// <summary>
    /// 看门狗，作为事件的发送者
    /// </summary>
    class WatchDoorDog
    {
        //1.声明关于事件的委托
        public delegate void AlarmEventHandler(object sender, EventArgs e);

        //2.声明事件
        public event AlarmEventHandler AlarmEvent;

        //3.编写触发事件的函数
        public void OnAlarm()
        {
            if(this.AlarmEvent != null)
            {
                Console.WriteLine("\n dog alarm!!! wangwangwang...,there is a 贼，起床抓贼了.........");
                
                this.AlarmEvent(this, new EventArgs());
            }
        }
    }
}
