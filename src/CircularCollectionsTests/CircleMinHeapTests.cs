using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Abstracts;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleMinHeapTests : ACircleHeapTests
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
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data1EntryWithSize2Mock);
            circleHeap.Push('0', 1);

            Assert.Equal('0', circleHeap._data[0].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data1EntryWithSize2Mock)[0].Value, circleHeap._data[1].Value);
        }

        [Fact]
        public void PushShouldAddHigherIndexElementToBottom()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data1EntryWithSize2Mock);
            circleHeap.Push('b', 9999);

            Assert.Equal('b', circleHeap._data[1].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data1EntryWithSize2Mock)[0].Value, circleHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddMidIndexElementToMiddle()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock);
            circleHeap.Push('b', 8);

            Assert.Equal(((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock)[0].Value, circleHeap._data[0].Value);
            Assert.Equal('b', circleHeap._data[1].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock)[1].Value, circleHeap._data[2].Value);
        }

        [Fact]
        public void PushHighToFullShouldLeaveUnchanged()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Push('d', 9999);

            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[0].Value, circleHeap._data[0].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[1].Value, circleHeap._data[1].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[2].Value, circleHeap._data[2].Value);
        }

        [Fact]
        public void PushToFullShouldOverwriteHighestValue()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Push('0', 1);

            Assert.Equal('0', circleHeap._data[0].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[0].Value, circleHeap._data[1].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[1].Value, circleHeap._data[2].Value);
        }

        [Fact]
        public void BottomShouldPointToElementAtLastFilledIndex()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.DataEmptySize3Mock);
            circleHeap.Push('b', 20);
            circleHeap.Push('a', 10);

            Assert.Equal('a', circleHeap._data[0].Value);
            Assert.Equal('b', circleHeap._data[1].Value);
            Assert.Equal(circleHeap._data[1].Value, circleHeap.Bottom);
        }

        [Fact]
        public void PopShouldRemoveElementAtPointer()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Rotate();
            circleHeap.Pop();

            Assert.Equal(2, circleHeap.Count);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[0].Value, circleHeap._data[0].Value);
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock)[2].Value, circleHeap._data[1].Value);
        }

        [Fact]
        public override void PeekShouldReturnElementAtPointer()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            circleHeap.Rotate();
            circleHeap.Rotate();
            circleHeap.Rotate();

            Assert.Equal(((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock)[3].Value, circleHeap.Peek());
            circleHeap.Reset();
            Assert.Equal(((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock)[0].Value, circleHeap.Peek());
        }

        [Fact]
        public void PopShouldReturnSameElementAsPeek()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            circleHeap.Rotate();
            circleHeap.Rotate();
            circleHeap.Rotate();

            Assert.Equal(circleHeap.Peek(), circleHeap.Pop());
        }

        [Fact]
        public void MergeShouldCombineElementsFromTwocircleHeaps()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data3EntriesWithSize5Mock);
            circleHeap.Merge(new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock));

            Assert.Equal(5, circleHeap.Count);
            Assert.Equal('a', circleHeap._data[0].Value);
            Assert.Equal('a', circleHeap._data[1].Value);
            Assert.Equal('b', circleHeap._data[2].Value);
            Assert.Equal('c', circleHeap._data[3].Value);
            Assert.Equal('c', circleHeap._data[4].Value);
        }

        [Fact]
        public void MergeShouldCombineMaxElementsFromTwoCircleMinHeaps()
        {
            ICircleHeap<char> circleHeap = new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Merge(new CircleMinHeap<char>((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock));

            Assert.Equal(3, circleHeap.Count);
            Assert.Equal('a', circleHeap._data[0].Value);
            Assert.Equal('a', circleHeap._data[1].Value);
            Assert.Equal('b', circleHeap._data[2].Value);
        }
    }
}
