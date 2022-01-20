using System;
using Xunit;
using Common;

namespace Tests
{
    public class PatternGeneratorTests
    {
        [Fact]
        private void BasicTest()
        {
            var res = new PatternGenerator().GetBools(5);
            var patt = new bool[] { true, false, false, true, false};
            Assert.Equal(patt,res);
        }
    }
}
