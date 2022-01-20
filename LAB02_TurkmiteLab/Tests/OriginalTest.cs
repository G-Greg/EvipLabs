using Xunit;
using LAB02_TurkmiteLab;

namespace Tests
{
    public class OriginalTest
    {
        [Fact]
        public void TestWhiteFieldStep()
        {
            var t = new OriginalTurkmite();
            var x = t.Step(t.white);
            Assert.Equal(-1, x.deltaDirection);
            Assert.Equal(t.black, x.NewColor);
        }
    }
}
