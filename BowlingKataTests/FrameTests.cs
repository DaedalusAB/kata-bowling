using System;
using BowlingKata;
using Xunit;

namespace BowlingKataTests
{
    public class FrameTests
    {
        [Fact]
        public void ANewFrameHasNoKnockedPins()
        {
            var frame = new Frame();

            Assert.Equal(0, frame.KnockedPins);
        }

        [Fact]
        public void AfterRollingInAFramePinsAreKnocked()
        {
            var frame = new Frame();

            frame.Roll(4);

            Assert.Equal(4, frame.KnockedPins);
        }

        [Fact]
        public void AfterRollingTwiceKnockedPinsAreAddedTogether()
        {
            var frame = new Frame();

            frame.Roll(4);
            frame.Roll(2);

            Assert.Equal(6, frame.KnockedPins);
        }

        [Fact]
        public void NoMoreThanTwoRollsCanBeMadePerFrame()
        {
            var frame = new Frame();

            frame.Roll(1);
            frame.Roll(1);

            Assert.Throws<InvalidOperationException>(() => frame.Roll(1));
        }

        [Fact]
        public void NoMoreThanTenPinsCanBeKnockedPerFrame()
        {
            var frame = new Frame();

            frame.Roll(5);
            Assert.Throws<ArgumentException>(() => frame.Roll(6));
        }

        [Fact]
        public void FrameWithSpare()
        {
            var frame = new Frame();

            frame.Roll(5);
            frame.Roll(5);

            Assert.Equal(10, frame.KnockedPins);
            Assert.True(frame.HasSpare);
        }
    }
}
