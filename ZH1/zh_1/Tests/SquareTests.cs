using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Common;
using System.Linq;

namespace Tests
{

    public class SquareTests
    {
        [Fact]
        private void FiveSquareTest()
        {
            var peldany = new SquareGenerator(5);
            var texts = peldany.GenerateTexts();
            Assert.True(texts.Any(t => t.Contains("25")));
        }
    }
}
