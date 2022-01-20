using Xunit;
using LAB02_TurkmiteLab;

namespace Tests
{
    public class BaseTest
    {
        [Fact]
        public void TestOrigRunCount()
        {
            var t = new OriginalTurkmite();
            Assert.Equal(13000, t.PreferredIterationCount);
        }

        [Fact]
        public void TestThreeRunCount()
        {
            var t = new ThreeColorTurkmite();
            Assert.Equal(500000, t.PreferredIterationCount);
        }
    }
}
