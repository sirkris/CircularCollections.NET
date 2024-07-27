using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Abstracts;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleMaxHeapTests : CircleHeapTests
    {
        public override ICircleHeapMocks Mocks { get; set; }

        public CircleMaxHeapTests() { Mocks = new CircleMaxHeapMocks(); }

        public override ICircleHeap<char> TestSetup(IHeapEntry<char>[] mock)
        {
            return new CircleMaxHeap<char>(mock);
        }

        [Fact]
        public void PushShouldAddHigherIndexElementToTop()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data1EntryWithSize2Mock);
            circleHeap.Push('0', 20);

            Assert.Equal('0', circleHeap._data[0].Value);
            Assert.Equal(Mocks.Data1EntryWithSize2Mock[0].Value, circleHeap._data[1].Value);
        }

        [Fact]
        public void PushShouldAddLowerIndexElementToBottom()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data1EntryWithSize2Mock);
            circleHeap.Push('b', 5);

            Assert.Equal('b', circleHeap._data[1].Value);
            Assert.Equal(Mocks.Data1EntryWithSize2Mock[0].Value, circleHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddMidIndexElementToMiddle()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data2EntriesWithSize3Mock);
            circleHeap.Push('b', 8);

            Assert.Equal(Mocks.Data2EntriesWithSize3Mock[0].Value, circleHeap._data[0].Value);
            Assert.Equal('b', circleHeap._data[1].Value);
            Assert.Equal(Mocks.Data2EntriesWithSize3Mock[1].Value, circleHeap._data[2].Value);
        }

        [Fact]
        public void PushLowToFullShouldLeaveUnchanged()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Push('d', 1);

            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[0].Value, circleHeap._data[0].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[1].Value, circleHeap._data[1].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[2].Value, circleHeap._data[2].Value);
        }

        [Fact]
        public void PushToFullShouldOverwriteLowestValue()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Push('0', 20);

            Assert.Equal('0', circleHeap._data[0].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[0].Value, circleHeap._data[1].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[1].Value, circleHeap._data[2].Value);
        }

        [Fact]
        public void BottomShouldPointToElementAtLastFilledIndex()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.DataEmptySize3Mock);
            circleHeap.Push('b', 10);
            circleHeap.Push('a', 20);

            Assert.Equal('a', circleHeap._data[0].Value);
            Assert.Equal('b', circleHeap._data[1].Value);
            Assert.Equal(circleHeap._data[1].Value, circleHeap.Bottom);
        }

        [Fact]
        public void PopShouldRemoveElementAtPointer()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Rotate();
            circleHeap.Pop();

            Assert.Equal(2, circleHeap.Count);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[0].Value, circleHeap._data[0].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[2].Value, circleHeap._data[1].Value);
        }

        [Fact]
        public override void PeekShouldReturnElementAtPointer()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data26EntriesWithSize26Mock);
            circleHeap.Rotate();
            circleHeap.Rotate();
            circleHeap.Rotate();

            Assert.Equal(Mocks.Data26EntriesWithSize26Mock[3].Value, circleHeap.Peek());
            circleHeap.Reset();
            Assert.Equal(Mocks.Data26EntriesWithSize26Mock[0].Value, circleHeap.Peek());
        }

        [Fact]
        public void PopShouldReturnSameElementAsPeek()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data26EntriesWithSize26Mock);
            circleHeap.Rotate();
            circleHeap.Rotate();
            circleHeap.Rotate();

            Assert.Equal(circleHeap.Peek(), circleHeap.Pop());
        }

        [Fact]
        public void MergeShouldCombineElementsFromTwocircleHeaps()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data3EntriesWithSize5Mock);
            circleHeap.Merge(TestSetup(Mocks.Data2EntriesWithSize3Mock));

            Assert.Equal(5, circleHeap.Count);
            Assert.Equal('a', circleHeap._data[0].Value);
            Assert.Equal('a', circleHeap._data[1].Value);
            Assert.Equal('b', circleHeap._data[2].Value);
            Assert.Equal('c', circleHeap._data[3].Value);
            Assert.Equal('c', circleHeap._data[4].Value);
        }

        [Fact]
        public void MergeShouldCombineMaxElementsFromTwocircleHeaps()
        {
            ICircleHeap<char> circleHeap = TestSetup(Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Merge(TestSetup(Mocks.Data2EntriesWithSize3Mock));

            Assert.Equal(3, circleHeap.Count);
            Assert.Equal('a', circleHeap._data[0].Value);
            Assert.Equal('a', circleHeap._data[1].Value);
            Assert.Equal('b', circleHeap._data[2].Value);
        }
    }
}
