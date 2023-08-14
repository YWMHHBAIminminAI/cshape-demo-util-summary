using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegateAndLambdaExercise
{
    class Program
    {
        public delegate double AddDelegate(double x ,double y);

        /// <summary>
        /// 定义一个用来运行委托AddDelegate的工具类
        /// </summary>
        /// <param name="str"></param>
        public static double AddDelegateRunMethod(AddDelegate addDelegate, double var1, double var2)
        {
            return addDelegate(var1, var2);
        }

        /// <summary>
        /// 定义AnimalPlayDelegate委托
        /// </summary>
        /// <param name="AnimalName"></param>
        delegate void AnimalPlayDelegate(string AnimalName);

        /// <summary>
        /// 定义一个用来运行委托AnimalPlayDelegate的工具类
        /// </summary>
        /// <param name="animalPlayDelegate"></param>
        /// <param name="name"></param>
        static void RunPlay(AnimalPlayDelegate animalPlayDelegate, string name)
        {
            animalPlayDelegate(name);
        }

       

        static void Main(string[] args)
        {
            PrintDogPlayProcess();
            Console.WriteLine("=====");
            PrintCatPlayProcess();
            Console.WriteLine("=====");
            PrintLionPlayProcess();
            Console.WriteLine("=====");
            PrintMultiDelegateProcess();
            Console.WriteLine("=====");
            PrintAnonymousFunctionCreateDelegateProcess();
            Console.WriteLine("=====");
            PrintAddProcess(500.1, 300.2);
            
        }

        /// <summary>
        /// 用委托实现的DogPlay
        /// </summary>
        public static void PrintDogPlayProcess()
        {
            IAnimalPlay dogPlay = new DogPlay();
            
            // 委托的用法一：
            AnimalPlayDelegate dogPlayDelegate = new AnimalPlayDelegate(dogPlay.StartPlay);
            RunPlay(dogPlayDelegate, "Dog");

            //委托的用法二：
            RunPlay(dogPlay.StartPlay, "Dog new format");
        }

        /// <summary>
        /// 用委托实现的CatPlay
        /// </summary>
        public static void PrintCatPlayProcess()
        {
            IAnimalPlay catPlay = new CatPlay();
            AnimalPlayDelegate catPlayDelegate = new AnimalPlayDelegate(catPlay.StartPlay);
            RunPlay(catPlayDelegate, "cat");
        }

        /// <summary>
        /// 用委托实现LionPay
        /// </summary>
        public static void PrintLionPlayProcess()
        {
            IAnimalPlay lionPlay = new LionPlay();
            AnimalPlayDelegate lionPlayDelegate = new AnimalPlayDelegate(lionPlay.StartPlay);
            RunPlay(lionPlayDelegate, "kitty lion");
        }

        /// <summary>
        /// 多播委托
        /// </summary>
        public static void PrintMultiDelegateProcess()
        {
            IAnimalPlay dogPlay = new DogPlay();
            AnimalPlayDelegate dogPlayDelegate = new AnimalPlayDelegate(dogPlay.StartPlay);

            dogPlayDelegate += new AnimalPlayDelegate(new CatPlay().StartPlay);

            dogPlayDelegate += new AnimalPlayDelegate(new LionPlay().StartPlay);

            RunPlay(dogPlayDelegate, "dog cat and lion");
        }

        /// <summary>
        /// 用匿名函数创建委托实例
        /// </summary>
        public static void PrintAnonymousFunctionCreateDelegateProcess()
        {
            AddDelegate addDelegate = delegate (double x, double y)
            {
                return 3 * x + 5;
            };

            double res = AddDelegateRunMethod(addDelegate, 11.1, 22.2);
            Console.WriteLine("result = {0}", res);
        }

        /// <summary>
        /// 用委托实现的两个double值相加
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void PrintAddProcess(double x, double y)
        {
            Calculator calculator = new Calculator();
            Func<double, double, double> AddRes = new Func<double, double, double>(calculator.Add);
            double z = 0D;
            z = AddRes(x, y);

            Console.WriteLine(z);
            Console.ReadLine();
        }
    }
}
