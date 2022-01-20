using System;
using System.Collections.Generic;
using Common;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var peldany = new DummyGenerator();
            peldany.N = 5;
            ShowTexts(peldany);

            var square = new SquareGenerator(10);
            var texts = square.GenerateTexts();
            foreach (var item in texts)
            {
                if (item.Contains("6"))
                    Console.WriteLine(item);
            }
        }

        static void ShowTexts(ITextSequenceSource obj)
        {
            List<string> texts = new List<string>();
            texts = obj.GenerateTexts().ToList();
            for (int i = 0; i < texts.Count; i++)
            {
                Console.WriteLine($"{i}. elem: " + texts[i]);
            }
        }
    }
}
