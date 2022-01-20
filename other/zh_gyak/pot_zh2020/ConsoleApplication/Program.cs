using Common;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var en = new Person("Greg", 21);
            ShowPersonDetails(en);

            var nem_en = new Student("Greg", 21, "J03NB2");
            ShowStudentsDetails(nem_en);
        }
        static void ShowPersonDetails(Person p)
        {
            Console.WriteLine(p.ToString());
        }
        static void ShowStudentsDetails(Student s)
        {
            Console.WriteLine(s.ToString()+s.NeptunCode);
        }
    }
}
