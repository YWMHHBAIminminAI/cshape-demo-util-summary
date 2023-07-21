using System;

/**
 * 这个类存在的问题就是类型膨胀
 * 此时咱们有两种商品，就得准备两种装商品的盒子
 * 后来生意越来越好的话，岂不是多少种商品就要准备多少种盒子
 * 
 */
namespace GenericDemo01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Apple apple = new Apple(){Color = "Red"};
            AppleBox appleBox = new AppleBox(){Cargo = apple};
            Console.WriteLine(appleBox.Cargo.Color);
            
            Toy toy = new Toy(){Name = "Tank"};
            ToyBox toyBox = new ToyBox(){Cargo = toy};
            Console.WriteLine(toyBox.Cargo.Name);
        }
    }

    /**
     * 商品一：Apple
     */
    public class Apple
    {
        public string Color { get; set; }
    }

    /**
     * 商品二：玩具
     */
    public class Toy
    {
        public string Name { get; set; }
    }

    /**
     * 装商品一苹果的盒子
     */
    public class AppleBox
    {
        /**
         * 代表装着货物的箱子
         */
        public Apple Cargo { get; set; }
    }

    /**
     * 装商品二玩具的盒子
     */
    public class ToyBox
    {
        public Toy Cargo { get; set; }
    }
}