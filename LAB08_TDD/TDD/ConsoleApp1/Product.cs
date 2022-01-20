using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public char Name { get; set; }
        public int Price { get; set; }
        public int PriceDiscountFrom { get; set; }
        public int AmountDiscountFrom { get; set; }
        public double PriceDiscount { get; set; }
        public int AmountGet { get; set; }
        public string Combo { get; set; }
        public int Allprice { get; set; }

        public Product(char name, int price)
        {
            Name = name;
            Price = price;
            PriceDiscountFrom = 0;
            PriceDiscount = 1;

        }

        public Product(char name, int discountFrom, double discount)
        {
            Name = name;
            Price = this.Price;
            PriceDiscountFrom = discountFrom;
            PriceDiscount = discount;

        }
        public Product(char name, int discountFrom, int get)
        {
            Name = name;
            Price = this.Price;
            AmountDiscountFrom = discountFrom;
            AmountGet = get;

        }

        public Product(string combo, int allprice)
        {
            Combo = combo;
            Allprice = allprice;
        }
    }
}
