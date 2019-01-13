using System;
using BowlingKata;
using Xunit;

namespace BowlingKataTests
{
    public class GameTests
    {
        [Fact]
        public void NewGameHasZeroScore()
        {
            var game = new Game();

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void GameWithOneRollHasScoreOfThatRoll()
        {
            var game = new Game();

            TakeSingleRoll(game, 1);

            Assert.Equal(1, game.Score());
        }

        [Fact]
        public void GameWithTwoFramesHasScoreOfBothFrames()
        {
            var game = new Game();

            TakeTwoRolls(game, 4, 4);
            TakeSingleRoll(game, 4);

            Assert.Equal(12, game.Score());
        }

        [Fact]
        public void GameWithAllFramesHasScoreOfAllFrames()
        {
            var game = new Game();

            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);


            Assert.Equal(80, game.Score());
        }

        [Fact]
        public void GameWithTenCompleteFramesCannotHaveMoreFrames()
        {
            var game = new Game();

            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);
            TakeTwoRolls(game, 4, 4);

            Assert.Throws<InvalidOperationException>(() => game.Roll(1));
        }

        private static void TakeSingleRoll(Game game, int roll)
        {
            game.Roll(roll);
        }


        private static void TakeTwoRolls(Game game, int firstRoll, int secondRoll)
        {
            game.Roll(firstRoll);
            game.Roll(secondRoll);
        }
    }
}
