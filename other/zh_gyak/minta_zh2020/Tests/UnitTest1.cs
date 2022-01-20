using System;
using Xunit;
using Common;
using System.Linq;

namespace Tests
{
    public class ZeroTests
    {
        [Fact]
        private void BasicTest() 
        {
            var peldany = new ZeroGenerator();
            peldany.n = 10;
            
            Assert.Equal(10, peldany.GenerateNumbers().Count());
        }
    }
}
