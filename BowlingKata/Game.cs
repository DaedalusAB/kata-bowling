using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Game
    {
        private readonly GameScoreService _scoreService;
        private const int FramesPerGame = 10;

        private readonly List<Frame> _frames;

        public Game(GameScoreService scoreService)
        {
            _scoreService = scoreService ?? throw new ArgumentNullException(nameof(scoreService));
            _frames = new List<Frame>();
        }

        public int Score()
        {
            var score = 0;

            foreach (var frame in _frames)
            {
                score += frame.KnockedPins;

                if (frame.HasSpare)
                    score += _scoreService.GetRollsAfterFrame(_frames, frame, 1);

                if (frame.HasStrike)
                    score += _scoreService.GetRollsAfterFrame(_frames, frame, 2);
            }

            return score;
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