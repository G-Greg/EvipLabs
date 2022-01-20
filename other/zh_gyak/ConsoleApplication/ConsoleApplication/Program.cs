using Common;
using System;
using System.Linq;


namespace ConsoleApplication
{
    class Program
    {
        static public void ShowBools(IBoolSource asd ,int a) 
        {
            Console.WriteLine(asd.GetBools(a).Where(r => r.Equals(true)).Count());
        }
        
        static void Main(string[] args)
        {
            var ez = new SimpleGenerator()
            { ValueToGenerator = true };
            ShowBools(ez, 5);

            var ezaz = new PatternGenerator();
            ShowBools(ezaz, 15);
        }
    }
}
