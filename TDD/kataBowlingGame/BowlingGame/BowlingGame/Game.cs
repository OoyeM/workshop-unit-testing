using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
        private int _currentRoll; 
        private int[] _rolls = new int[21];


        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                //spare
                if (IsSpare(roll))
                {
                    score += 10 + _rolls[roll + 2];
                } else if (IsStrike(roll))
                {
                    score += 10
                + StrikeBonus(roll);

                    roll++;

                }
                else
                {
                    score += _rolls[roll] + _rolls[roll + 1];
                }

                roll += 2;
            }

            return score;
        }
        private bool IsSpare(int roll)
        {
            return _rolls[roll] +
                _rolls[roll + 1] == 10;
        }
        private bool IsStrike(int roll)
        {
            return _rolls[roll] == 10;
        }
    }
}