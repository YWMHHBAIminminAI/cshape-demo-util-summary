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
            
            CommonBox boxApple = new CommonBox();
            CommonBox boxToy = new CommonBox();
            //...
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
     * 统一用来装商品的盒子
     */
    public class CommonBox
    {
        /**
         * 代表装着货物的箱子
         */
        public Apple apple { get; set; }
        public Toy toy { get; set; }
        //...数不清的许许多多的需要装进盒里的商品
    }
}