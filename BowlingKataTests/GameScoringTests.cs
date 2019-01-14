using BowlingKata;
using Xunit;

namespace BowlingKataTests
{
    public class GameScoringTests
    {
        [Fact]
        public void SpareThenRegularFrame()
        {
            var game = new Game(new GameScoreService());

            game.TakeTwoRolls(5, 5);
            game.TakeOneRoll(5);

            Assert.Equal(20, game.Score());

        }

        [Fact]
        public void StrikeThenRegularFrame()
        {
            var game = new Game(new GameScoreService());

            game.TakeOneRoll(10);
            game.TakeTwoRolls(5, 4);

            Assert.Equal(28, game.Score());
        }

        [Fact]
        public void TwoSparesThenFrame()
        {
            var game = new Game(new GameScoreService());

            game.TakeTwoRolls(5, 5);
            game.TakeTwoRolls(5, 5);
            game.TakeTwoRolls(1, 1);

            Assert.Equal(28, game.Score());
        }

        [Fact]
        public void TwoStrikesThenAFrame()
        {
            var game = new Game(new GameScoreService());

            game.Strike();
            game.Strike();
            game.TakeTwoRolls(1, 1);

            Assert.Equal(35, game.Score());
        }

        [Fact]
        public void SpareThenNoRolls()
        {
            var game = new Game(new GameScoreService());

            game.TakeTwoRolls(4, 6);

            Assert.Equal(10, game.Score());
        }

        [Fact]
        public void StrikeThenOnlyOneRoll()
        {
            var game = new Game(new GameScoreService());

            game.Strike();
            game.TakeOneRoll(1);

            Assert.Equal(12, game.Score());
        }
    }
}
