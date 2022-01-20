using LAB02_TurkmiteLab;
using Xunit;

namespace Tests
{
    public class ThreeColorTurkmiteTest
    {
        [Fact]
        public void TestThreeColorStep()
        {
            var t = new ThreeColorTurkmite();
            var x = t.Step(t.red);
            Assert.Equal(-1, x.deltaDirection);
            Assert.Equal(t.yellow, x.NewColor);
        }
    }
}
