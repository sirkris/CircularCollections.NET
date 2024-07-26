using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Abstracts;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleMinHeapTests : CircleHeapTests
    {
        public override ICircleHeapMocks Mocks { get; set; }

        public CircleMinHeapTests() { Mocks = new CircleMinHeapMocks(); }

        public override ICircleHeap<char> TestSetup(IHeapEntry<char>[] mock)
        {
            return new CircleMinHeap<char>(mock);
        }

        [Fact]
        public void PushShouldAddLowerIndexElementToTop()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data1EntryWithSize2Mock);
            circleMinHeap.Push('0', 1);

            Assert.Equal('0', circleMinHeap._data[0].Value);
            Assert.Equal(Mocks.Data1EntryWithSize2Mock[0].Value, circleMinHeap._data[1].Value);
        }

        [Fact]
        public void PushShouldAddHigherIndexElementToBottom()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data1EntryWithSize2Mock);
            circleMinHeap.Push('b', 9999);

            Assert.Equal('b', circleMinHeap._data[1].Value);
            Assert.Equal(Mocks.Data1EntryWithSize2Mock[0].Value, circleMinHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddMidIndexElementToMiddle()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data2EntriesWithSize3Mock);
            circleMinHeap.Push('b', 8);

            Assert.Equal(Mocks.Data2EntriesWithSize3Mock[0].Value, circleMinHeap._data[0].Value);
            Assert.Equal('b', circleMinHeap._data[1].Value);
            Assert.Equal(Mocks.Data2EntriesWithSize3Mock[1].Value, circleMinHeap._data[2].Value);
        }

        [Fact]
        public void PushHighToFullShouldLeaveUnchanged()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Push('d', 9999);

            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[0].Value, circleMinHeap._data[0].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[1].Value, circleMinHeap._data[1].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[2].Value, circleMinHeap._data[2].Value);
        }

        [Fact]
        public void PushToFullShouldOverwriteHighestValue()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Push('0', 1);

            Assert.Equal('0', circleMinHeap._data[0].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[0].Value, circleMinHeap._data[1].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[1].Value, circleMinHeap._data[2].Value);
        }

        [Fact]
        public void BottomShouldPointToElementAtLastFilledIndex()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.DataEmptySize3Mock);
            circleMinHeap.Push('b', 20);
            circleMinHeap.Push('a', 10);

            Assert.Equal('a', circleMinHeap._data[0].Value);
            Assert.Equal('b', circleMinHeap._data[1].Value);
            Assert.Equal(circleMinHeap._data[1].Value, circleMinHeap.Bottom);
        }

        [Fact]
        public void PopShouldRemoveElementAtPointer()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Pop();

            Assert.Equal(2, circleMinHeap.Count);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[0].Value, circleMinHeap._data[0].Value);
            Assert.Equal(Mocks.Data3EntriesWithSize3Mock[2].Value, circleMinHeap._data[1].Value);
        }

        [Fact]
        public void PeekShouldReturnElementAtPointer()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data26EntriesWithSize26Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();

            Assert.Equal(Mocks.Data26EntriesWithSize26Mock[3].Value, circleMinHeap.Peek());
            circleMinHeap.Reset();
            Assert.Equal(Mocks.Data26EntriesWithSize26Mock[0].Value, circleMinHeap.Peek());
        }

        [Fact]
        public void PopShouldReturnSameElementAsPeek()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data26EntriesWithSize26Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();

            Assert.Equal(circleMinHeap.Peek(), circleMinHeap.Pop());
        }

        [Fact]
        public void MergeShouldCombineElementsFromTwocircleMinHeaps()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data3EntriesWithSize5Mock);
            circleMinHeap.Merge(new CircleMinHeap<char>(Mocks.Data2EntriesWithSize3Mock));

            Assert.Equal(5, circleMinHeap.Count);
            Assert.Equal('a', circleMinHeap._data[0].Value);
            Assert.Equal('a', circleMinHeap._data[1].Value);
            Assert.Equal('b', circleMinHeap._data[2].Value);
            Assert.Equal('c', circleMinHeap._data[3].Value);
            Assert.Equal('c', circleMinHeap._data[4].Value);
        }

        [Fact]
        public void MergeShouldCombineMaxElementsFromTwoCircleMinHeaps()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(Mocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Merge(new CircleMinHeap<char>(Mocks.Data2EntriesWithSize3Mock));

            Assert.Equal(3, circleMinHeap.Count);
            Assert.Equal('a', circleMinHeap._data[0].Value);
            Assert.Equal('a', circleMinHeap._data[1].Value);
            Assert.Equal('b', circleMinHeap._data[2].Value);
        }
    }
}
