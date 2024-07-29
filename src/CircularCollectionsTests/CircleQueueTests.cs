using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Abstracts;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleQueueTests : ACircleQueueTests
    {
        public override ICircleQueueMocks Mocks { get; set; }

        public CircleQueueTests() { Mocks = new CircleQueueMocks(); }

        public override ICircleQueue<char> TestSetup(char[] mock)
        {
            return new CircleQueue<char>(mock);
        }
    }
}
