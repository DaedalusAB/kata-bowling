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
            return _frames.Sum(f => f.KnockedPins);
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