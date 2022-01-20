using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var peldany = new ZeroGenerator();
            peldany.n = 5;
            ShowNumbers(peldany);

            var prim = new PrimeGenerator(100).GenerateNumbers();
            Console.WriteLine(prim.Where(n => (n % 10).Equals(3)).Count());
            
        }

        static void ShowNumbers(INumberSequenceSource obj)
        {
            List<int> szamok = new List<int>();
            szamok = obj.GenerateNumbers().ToList();
            for (int i = 0; i < szamok.Count; i++)
            {
                Console.WriteLine($"{i}. elem: "+szamok[i]);
            }
            
        }
    }
}
