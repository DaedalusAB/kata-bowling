using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class GameScoreService
    {
        public int GetRollsAfterFrame(IEnumerable<Frame> allFrames, Frame frame, int rollCount)
        {
            var frameIndex = allFrames
                .ToList()
                .IndexOf(frame);

            return allFrames
                .Skip(frameIndex + 1)
                .SelectMany(f => f.Rolls)
                .ToArray()
                .Take(rollCount)
                .Sum();
        }
    }
}