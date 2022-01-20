using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    class Shop
    {
        private int FELADAT = 1;

        public Dictionary<char, Product> products = new Dictionary<char, Product>();
        public void RegisterProduct(char name, int price)
        {
            if (!products.ContainsKey(name))
            {
                products.Add(name, new Product(name, price));
            }
            else
            {
                products[name].Price = price;
            }
        }
        public void RegisterAmountDiscount(char name, int discountFrom, double discount)
        {
            if (products.ContainsKey(name))
            {
                products[name].PriceDiscountFrom = discountFrom;
                products[name].PriceDiscount = discount;
            }
        }

        public void RegisterCountDiscount(char name, int discountFrom, int get)
        {
            if (products.ContainsKey(name))
            {
                products[name].AmountDiscountFrom = discountFrom;
                products[name].AmountGet = get;
            }
        }

        public void RegisterComboDiscount(string combo, int price)
        {
            foreach (var item in combo)
            {
                products[item].Combo = combo;
                products[item].Allprice = price;
            }
        }

        public double GetPrice(string list)
        {
            string types = getTypes(list);
            double price = 0;

            foreach (var t in types)
            {
                int count = list.Count(f => f.Equals(t));

                if (!t.Equals('t'))
                {

                    if (FELADAT == 1)
                    {
                        //10% kedvezmény
                        if (count >= products[t].PriceDiscountFrom)
                            price += products[t].Price * count * products[t].PriceDiscount;
                        else
                            price += products[t].Price * count;
                    }
                    else if (FELADAT == 2)
                    {
                        //3 áráért 4-et vihet kedvezmény
                        if (count >= products[t].AmountGet && products[t].AmountGet > 1)
                            price += products[t].Price * (count * (count / products[t].AmountDiscountFrom) - (products[t].AmountGet - products[t].AmountDiscountFrom));
                        else
                            price += products[t].Price * count;
                    }
                    else if (FELADAT == 3)
                    {
                        //kombó kedvezmény
                        if (types.Contains('A') && types.Contains('B') && types.Contains('C'))
                        {
                            price += products[t].Allprice + products['A'].Price * (list.Count(f => f.Equals('A')) - 1) + products['B'].Price * (list.Count(f => f.Equals('B')) - 1) + products['C'].Price * (list.Count(f => f.Equals('C')) - 1);
                            break;
                        }
                    }
                }
            }
            if (types.Contains('t'))
                return price * 0.90;
            return price;
        }

        public string getTypes(string list) 
        {
            string types = "";
            var asd = list.ToCharArray();
            foreach (var t in asd)
            {
                if (!types.Contains(t))
                    types += t;
            }
            return types;
        }
    }
}
