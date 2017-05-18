using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        [TestMethod]
        public void AllGutterBallsResultsInScoreOfZer0()
        {
            var rolls = RollMany(0, 20, 0);

            var score = game.GetScore(rolls);

            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void RollingAllOnesResultsInScoreOfTwenty()
        {
            var rolls = RollMany(1, 20, 0);

            var score = game.GetScore(rolls);

            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void RollingASpareThenAFiveFollowedByAllGuttersResultsInScoreOfTwenty()
        {
            var rolls = RollMany(0, 20, 3);
            rolls[0] = 9;
            rolls[1] = 1;
            rolls[2] = 5;
            var score = game.GetScore(rolls);

            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void RollingAStrikeThenASpareOnTenthFrameResultsInScoreOf()
        {
            var rolls = RollMany(0, 21, 0);
            rolls[18] = 10;
            rolls[19] = 1;
            rolls[20] = 9;
            var score = game.GetScore(rolls);

            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void RollingAStrikeThenAFiveAndAThreeFollowedByAllGuttersResultsInScoreOfTwenty()
        {
            var rolls = RollMany(0, 19, 3);
            rolls[0] = 10;
            rolls[1] = 5;
            rolls[2] = 3;
            var score = game.GetScore(rolls);

            Assert.AreEqual(26, score);
        }

        [TestMethod]
        public void RollingAGutterThenFiveThenFiveThenThreeFollowedByAllGuttersResultsInScoreOfThirteen()
        {
            var rolls = RollMany(0, 20, 3);
            rolls[0] = 0;
            rolls[1] = 5;
            rolls[2] = 5;
            rolls[3] = 3;
            var score = game.GetScore(rolls);

            Assert.AreEqual(13, score);
        }

        [TestMethod]
        public void PerfectGameIsThreeHundred()
        {
            var rolls = RollMany(10, 12, 0);

            var score = game.GetScore(rolls);

            Assert.AreEqual(300, score);
        }

        private static Int32[] RollMany(Int32 rollScore, Int32 totalNumberOfRolls, Int32 startingAtIndex)
        {
            var rolls = new Int32[totalNumberOfRolls];

            for (var i = startingAtIndex; i < rolls.Length; i++)
                rolls[i] = rollScore;

            return rolls;
        }
    }
}