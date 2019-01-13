using System;

namespace BowlingKata
{
    public class Frame
    {
        private const int PinsPerFrame = 10;
        private const int RollsPerFrame = 2;

        private int _rollsMade;

        public int KnockedPins { get; private set; }

        public bool HasSpare =>
            _rollsMade == RollsPerFrame && KnockedPins == PinsPerFrame;

        public bool HasStrike =>
            _rollsMade == 1 && KnockedPins == PinsPerFrame;

        public bool Completed =>
            HasStrike || _rollsMade == RollsPerFrame;

        public void Roll(int knockedPins)
        {
            if(_rollsMade == RollsPerFrame) 
                throw new InvalidOperationException(nameof(Roll));

            if(KnockedPins + knockedPins > PinsPerFrame)
                throw new ArgumentException(nameof(knockedPins));

            _rollsMade++;
            KnockedPins += knockedPins;
        }
    }
}
