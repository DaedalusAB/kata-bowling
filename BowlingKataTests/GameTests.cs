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
            var game = new Game(new GameScoreService());

            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void GameWithOneRollHasScoreOfThatRoll()
        {
            var game = new Game(new GameScoreService());

            game.TakeOneRoll(1);

            Assert.Equal(1, game.Score());
        }

        [Fact]
        public void GameWithTwoFramesHasScoreOfBothFrames()
        {
            var game = new Game(new GameScoreService());

            game.TakeTwoRolls(4, 4);
            game.TakeOneRoll(4);

            Assert.Equal(12, game.Score());
        }

        [Fact]
        public void GameWithAllFramesHasScoreOfAllFrames()
        {
            var game = new Game(new GameScoreService());

            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);


            Assert.Equal(80, game.Score());
        }

        [Fact]
        public void GameWithTenCompleteFramesCannotHaveMoreFrames()
        {
            var game = new Game(new GameScoreService());

            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);
            game.TakeTwoRolls(4, 4);

            Assert.Throws<InvalidOperationException>(() => game.Roll(1));
        }
    }
}
