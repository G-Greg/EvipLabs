﻿using Numbers;
using Xunit;

namespace Tests
{
    public class PrimeTest
    {
        [Fact]
        public void CountPrimeNumbers100Returns25()
        {
            var p = new CountPrimeNumbers(100);
            Assert.Equal(25, p.CalculateSolution());
        }
    }
}
