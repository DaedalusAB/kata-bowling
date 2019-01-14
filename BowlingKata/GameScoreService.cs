using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class GameScoreService
    {
        public int CalculateScore(List<Frame> frames)
        {
            var score = 0;

            foreach (var frame in frames)
            {
                score += frame.KnockedPins;

                if (frame.HasSpare)
                    score += GetRollsAfterFrame(frames, frame, 1);

                if (frame.HasStrike)
                    score += GetRollsAfterFrame(frames, frame, 2);
            }

            return score;
        }

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