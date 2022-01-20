using System;
using Xunit;
using Common;

namespace Tests
{
    public class PrimeTests
    {
        [Fact]
        private void FivePrimeTest()
        {
            var answer = new int[] {2,3,5,7,11};
            var res = new PrimeGenerator(5).GenerateNumbers();
            Assert.Equal(answer, res);
        }
    }
}
