using System;
using BowlingGame;
using Xunit;

namespace BowlingGameTest
{
    public class GameTest
    {
        private readonly Game _g;


        public GameTest()
        {
            _g = new Game();

        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _g.Roll(pins);
            }
        }

        [Fact]
        public void TestGutterGame()
        {
            int rolls = 20;
            int pins = 0;
            RollMany(rolls, pins);
            Assert.Equal(0, _g.Score());
        }
      

        [Fact]
        public void TestAllOnes()
        {

            int rolls = 20;
            int pins = 1;
            RollMany(rolls, pins);

            Assert.Equal(20, _g.Score());
        }
        [Fact]
        public void TestOneSpare()
        {
            _g.Roll(5);
            _g.Roll(5); // spare
            _g.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, _g.Score());
        }
        [Fact]
        public void TestOneStrike()
        {
            g.Roll(10); // strike
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.Score());
        }

    }
}
