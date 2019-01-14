using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class GameScoreService
    {
        public int GetRollAfterFrame(IEnumerable<Frame> allFrames, Frame frame)
        {
            var frameIndex = allFrames
                .ToList()
                .IndexOf(frame);

            return allFrames
                .Skip(frameIndex + 1)
                .SelectMany(f => f.Rolls)
                .Take(1)
                .Sum();
        }

        public int GetTwoRollsAfterFrame(IEnumerable<Frame> allFrames, Frame frame)
        {
            var frameIndex = allFrames
                .ToList()
                .IndexOf(frame);

            var rollsAfterFrame = allFrames
                .Skip(frameIndex + 1)
                .SelectMany(f => f.Rolls)
                .ToArray();

            return rollsAfterFrame.Take(2).Sum();
        }
    }
}