using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Abstracts;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleStackTests : ACircleStackTests
    {
        public override ICircleQueueAndStackMocks Mocks { get; set; }

        public CircleStackTests() { Mocks = new CircleStackMocks(); }

        public override ICircleStack<char> TestSetup(char[] mock)
        {
            return new CircleStack<char>(mock);
        }
    }
}
