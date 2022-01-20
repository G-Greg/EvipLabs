using System;
using Xunit;
using Common;

namespace Tests
{
    public class SimpleGeneratorUnitTest
    {
        
        [Fact]
       public void BaseTest()
       {
            var asd = new SimpleGenerator().GetBools(10);
            foreach (var item in asd)
            {
                Assert.True(item);
            }
       }

    }
}
