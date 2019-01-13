using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingKata
{
    public static class GameExtensions
    {
        public static void Strike(this Game game)
        {
            game.TakeOneRoll(10);
        }

        public static void TakeOneRoll(this Game game, int roll)
        {
            game.Roll(roll);
        }

        public static void TakeTwoRolls(this Game game, int firstRoll, int seconeRoll)
        {
            game.Roll(firstRoll);
            game.Roll(seconeRoll);
        }
    }
}
