using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Frame
    {
        private const int PinsPerFrame = 10;
        private const int RollsPerFrame = 2;

        private readonly List<int> _rolls;

        public Frame()
        {
            _rolls = new List<int>();
        }

        public void Roll(int knockedPins)
        {
            if (RollsMade == RollsPerFrame)
                throw new InvalidOperationException(nameof(Roll));

            if (KnockedPins + knockedPins > PinsPerFrame)
                throw new ArgumentException(nameof(knockedPins));

            _rolls.Add(knockedPins);
        }

        private int RollsMade =>
            _rolls.Count;

        public int KnockedPins =>
            _rolls.Sum();

        public bool HasSpare =>
            RollsMade == RollsPerFrame && KnockedPins == PinsPerFrame;

        public bool HasStrike =>
            RollsMade == 1 && KnockedPins == PinsPerFrame;

        public bool Completed =>
            HasStrike || RollsMade == RollsPerFrame;

        public IEnumerable<int> Rolls =>
            _rolls;
    }
}
