using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop Shop = new Shop();

            //alap
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('C', 20);
            Shop.RegisterProduct('E', 50);
            var price = Shop.GetPrice("ACEE");//      130

            //P01
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 100);
            Shop.RegisterAmountDiscount('A', 5, 0.9);
            var price2 = Shop.GetPrice("AAAAAAB");//  154


            //P02
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('E', 50);
            Shop.RegisterCountDiscount('A', 3, 4);
            var price3 = Shop.GetPrice("AAAAAEEE");// 190


            //P03
            Shop.RegisterProduct('A', 10);
            Shop.RegisterProduct('B', 20);
            Shop.RegisterProduct('C', 50);
            Shop.RegisterProduct('D', 100);
            Shop.RegisterComboDiscount("ABC", 60);
            var price4 = Shop.GetPrice("CAAAABB");// 110

            //P04
            Shop.RegisterProduct('D', 100);
            var price5 = Shop.GetPrice("tD"); //    90


            Console.WriteLine(price5);
        }
    }
}
