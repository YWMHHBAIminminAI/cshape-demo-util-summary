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
            Toy toy = new Toy(){Name = "Weapon"};
            CommonBox<Apple> appBox = new CommonBox<Apple>(){Cargo = apple};
            CommonBox<Toy> toyBox = new CommonBox<Toy>(){Cargo = toy};
            Console.WriteLine(appBox.Cargo.Color);
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
     * <TCargo>代表CommonBox装的都Cargo类型的货物
     */
    public class CommonBox<TCargo> 
    {
        public TCargo Cargo { get; set; }
    }
}