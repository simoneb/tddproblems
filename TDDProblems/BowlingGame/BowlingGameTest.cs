using NUnit.Framework;

namespace TDDProblems.BowlingGame
{
    [TestFixture]
    public class BowlingGameTest
    {
        private BowlingGame g;

        [SetUp]
        public void Setup()
        {
            g = new BowlingGame();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                g.Roll(pins);
        }

        [Test]
        public void GutterGame()
        {
            RollMany(20, 0);

            Assert.AreEqual(0, g.GetScore());
        }

        [Test]
        public void AllOnes()
        {
            RollMany(20, 1);

            Assert.AreEqual(20, g.GetScore());
        }

        [Test]
        public void OneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, g.GetScore());
        }

        [Test]
        public void OneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, g.GetScore());
        }

        [Test]
        public void PerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, g.GetScore());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}