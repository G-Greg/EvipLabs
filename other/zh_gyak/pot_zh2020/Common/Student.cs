using System;
using System.Text.RegularExpressions;

namespace Common
{
    public class Student : Person
    {
        public string NeptunCode { get; set; }


        public Student(string name, int age, string neptun): base(name, age)
        {
            var regex = new Regex(@"^[A-Z0-9]{6}$");
            Match match = regex.Match(neptun);
            if (match.Success)
                NeptunCode = neptun;
            else
                throw new ArgumentException();
        }
    }
}
