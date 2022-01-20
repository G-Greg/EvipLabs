using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Common;

namespace Tests
{
    public class DummyTests
    {
        [Fact]
        private void BasicTest()
        {
            var peldany = new DummyGenerator();
            peldany.N = 10;
            Assert.Equal(10, peldany.GenerateTexts().Count());
        }
    }
}
