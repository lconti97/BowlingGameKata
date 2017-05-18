using System;

namespace BowlingGame
{
    public class Game
    {
        public Int32 GetScore(Int32[] rolls)
        {
            var score = 0;
            var firstRollInFrame = 0;

            for (var frame = 1; frame <= 9; frame++)
            {
                if (IsStrike(rolls[firstRollInFrame]))
                {
                    score += GetStrikeScore(rolls, firstRollInFrame);
                    firstRollInFrame++;
                }
                else
                {
                    if (IsSpare(rolls, firstRollInFrame))
                        score += GetSpareScore(rolls, firstRollInFrame);
                    else
                        score += GetScoreForFrame(rolls, firstRollInFrame);

                    firstRollInFrame += 2;
                }
            }

            score += GetScoreForTenthFrame(rolls, firstRollInFrame);

            return score;
        }

        private static Int32 GetScoreForTenthFrame(Int32[] rolls, Int32 firstRollInFrame)
        {
            var tenthFrameScore = GetScoreForFrame(rolls, firstRollInFrame);

            if (HasBonusRoll(rolls, firstRollInFrame))
                tenthFrameScore += rolls[firstRollInFrame + 2];

            return tenthFrameScore;
        }

        private static Boolean HasBonusRoll(Int32[] rolls, Int32 i)
        {
            return i + 2 < rolls.Length;
        }

        private static Boolean IsSpare(Int32[] rolls, Int32 i)
        {
            return GetScoreForFrame(rolls, i) == 10;
        }

        private static Boolean IsStrike(Int32 rollScore)
        {
            return rollScore == 10;
        }

        private static Int32 GetSpareScore(Int32[] rolls, Int32 i)
        {
            return rolls[i + 2] + 10;
        }

        private static Int32 GetStrikeScore(Int32[] rolls, Int32 i)
        {
            return rolls[i + 1] + rolls[i + 2] + 10;
        }

        private static Int32 GetScoreForFrame(Int32[] rolls, Int32 i)
        {
            return rolls[i] + rolls[i + 1];
        }
    }
}
