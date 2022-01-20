using Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class PersonTests
    {
        [Fact]
        private void PersonToStringTest()
        {
            var peldany = new Person("Aladár", 22);
            string sol = "Hello, I'm Aladár and 22 years old.";
            Assert.Equal(peldany.ToString(), sol);
        }
    }
}
