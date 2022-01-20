using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Common;

namespace Tests
{
    public class StudentTests
    {
        [Fact]
        private void StudentTestSuccess()
        {
            var p = new Student("Béla", 20, "B1TM4N");
            string sol = "Hello, I'm Béla and 20 years old.";
            Assert.Equal(sol, p.ToString());
        }

        [Fact]
        private void StudentTestExection()
        {
            Assert.Throws<ArgumentException>(() => new Student("Cecil", 42, "Cecil.42"));
        }
    }
}
