using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string ToString()
        {
            return $"Hello, I'm {Name}"+$" and {Age} years old.";
        }
    }
}
