using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private const int FramesPerGame = 10;

        private readonly List<Frame> _frames;

        public Game()
        {
            _frames = new List<Frame>();
        }

        public int Score()
        {
            var score = 0;

            foreach (var frame in _frames)
            {
                score += frame.KnockedPins;

                if (frame.HasSpare)
                    score += GetRollAfterFrame(frame);

                if (frame.HasStrike)
                    score += GetTwoRollAfterFrame(frame);
            }

            return score;
        }

        private int GetRollAfterFrame(Frame frame)
        {
            var frameIndex = _frames.IndexOf(frame);
            var rollIndex = 0;

            for (var i = 0; i <= frameIndex; i++)
                rollIndex += _frames[i].Rolls.Count();

            return _frames.SelectMany(f => f.Rolls).ToArray()[rollIndex];
        }

        private int GetTwoRollAfterFrame(Frame frame)
        {
            var frameIndex = _frames.IndexOf(frame);
            var rollIndex = 0;

            for (var i = 0; i <= frameIndex; i++)
                rollIndex += _frames[i].Rolls.Count();

            var allRolls = _frames.SelectMany(f => f.Rolls).ToArray();

            return allRolls[rollIndex] + allRolls[rollIndex + 1];
        }


        public void Roll(int knockedPins)
        {
            if (CompletedFrames == FramesPerGame)
                throw new InvalidOperationException();

            if (CurrentFrame == null || CurrentFrame.Completed)
                _frames.Add(new Frame());

            CurrentFrame?.Roll(knockedPins);
        }

        private Frame CurrentFrame =>
            _frames.LastOrDefault();

        private int CompletedFrames =>
            _frames.Count(f => f.Completed);
    }
}