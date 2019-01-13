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
           return  _frames.Sum(f => f.KnockedPins);
        }

        public void Roll(int knockedPins)
        {
            if (CurrentFrame != null && !CurrentFrame.Completed)
            {
                CurrentFrame.Roll(knockedPins);
            }
            else if(CompletedFrames < FramesPerGame)
            {
                NewFrame().Roll(knockedPins);
            }
            else 
                throw new InvalidOperationException();
        }

        private Frame CurrentFrame =>
            _frames.LastOrDefault();

        private Frame NewFrame()
        {
            var newFrame = new Frame();
            _frames.Add(newFrame);

            return newFrame;
        }

        private int CompletedFrames =>
            _frames.Count;
    }
}