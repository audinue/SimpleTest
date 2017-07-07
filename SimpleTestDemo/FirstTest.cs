using SimpleTest;

namespace SimpleTestDemo
{
    public class FirstTest : Test
    {
        public void ShouldSuccess()
        {
            Assert(true);
        }

        public void ShouldFail()
        {
            Assert(false);
        }
    }
}
