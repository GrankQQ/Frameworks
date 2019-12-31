using LeeCodeAnswers;
using NUnit.Framework;

namespace Tests
{
    public class ChangeLettersTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            ChangeLetters change = new ChangeLetters();
            Assert.AreEqual(1, change.MinimumSwap("xx", "yy"));
            Assert.AreEqual(2, change.MinimumSwap("xy", "yx"));
            Assert.AreEqual(-1, change.MinimumSwap("xx", "xy"));
            Assert.AreEqual(4, change.MinimumSwap("xxyyxyxyxx", "xyyxyxxxyx"));
            Assert.Pass();
        }
    }
}