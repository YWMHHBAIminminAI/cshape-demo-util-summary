using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            //Body作为事件的响应者
            Body body = new Body();
            Girl girl = new Girl();
            /**
             * 用+=把+=右边的函数挂到+=左边的事件上，按tab键实现。也就是当+=左边的这个事件发生时+=右边的函数就会执行。+=右边这个方法响应+=左边这个事件，所以+=右边的函数或者方法也叫事件处理器
             */
            timer.Elapsed += body.Action;
            timer.Elapsed += girl.Action;
            timer.Start();
            Console.ReadLine();
        }

        private static void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    class Body
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump");
        }
    }

    class Girl
    {
        internal void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing!");
        }
    }


}
