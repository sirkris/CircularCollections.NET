using Collections.Generic.Circular;
using CircularTests.Mocks;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleMinHeapTests
    {
        [Fact]
        public void PushShouldAddInitialElement()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.DataEmptySize1Mock);
            circleMinHeap.Push('a', 10);

            Assert.Equal('a', circleMinHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddLowerIndexElementToTop()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data1EntryWithSize2Mock);
            circleMinHeap.Push('0', 1);

            Assert.Equal('0', circleMinHeap._data[0].Value);
            Assert.Equal(CircleMinHeapMocks.Data1EntryWithSize2Mock[0].Value, circleMinHeap._data[1].Value);
        }

        [Fact]
        public void PushShouldAddHigherIndexElementToBottom()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data1EntryWithSize2Mock);
            circleMinHeap.Push('b', 9999);

            Assert.Equal('b', circleMinHeap._data[1].Value);
            Assert.Equal(CircleMinHeapMocks.Data1EntryWithSize2Mock[0].Value, circleMinHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddMidIndexElementToMiddle()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data2EntriesWithSize3Mock);
            circleMinHeap.Push('b', 8);

            Assert.Equal(CircleMinHeapMocks.Data2EntriesWithSize3Mock[0].Value, circleMinHeap._data[0].Value);
            Assert.Equal('b', circleMinHeap._data[1].Value);
            Assert.Equal(CircleMinHeapMocks.Data2EntriesWithSize3Mock[1].Value, circleMinHeap._data[2].Value);
        }

        [Fact]
        public void PushHighToFullShouldLeaveUnchanged()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Push('d', 9999);

            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[0].Value, circleMinHeap._data[0].Value);
            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[1].Value, circleMinHeap._data[1].Value);
            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[2].Value, circleMinHeap._data[2].Value);
        }

        [Fact]
        public void PushToFullShouldOverwriteHighestValue()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Push('0', 1);

            Assert.Equal('0', circleMinHeap._data[0].Value);
            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[0].Value, circleMinHeap._data[1].Value);
            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[1].Value, circleMinHeap._data[2].Value);
        }

        [Fact]
        public void PointerShouldStartAtTop()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            Assert.Equal(circleMinHeap.Top, circleMinHeap._data[circleMinHeap.Pointer].Value);
        }

        [Fact]
        public void TopShouldPointToElementAtIndexZero()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            Assert.Equal(circleMinHeap._data[0].Value, circleMinHeap.Top);
        }

        [Fact]
        public void BottomShouldPointToElementAtLastFilledIndex()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.DataEmptySize3Mock);
            circleMinHeap.Push('b', 20);
            circleMinHeap.Push('a', 10);

            Assert.Equal('a', circleMinHeap._data[0].Value);
            Assert.Equal('b', circleMinHeap._data[1].Value);
            Assert.Equal(circleMinHeap._data[1].Value, circleMinHeap.Bottom);
        }

        [Fact]
        public void SizeShouldEqualConstructorInputDataLength()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.DataEmptySize3Mock);
            Assert.Equal(CircleMinHeapMocks.DataEmptySize3Mock.Length, circleMinHeap.Size);
        }

        [Fact]
        public void SizeShouldEqualDataLength()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.DataEmptySize3Mock);
            Assert.Equal(circleMinHeap._data.Length, circleMinHeap.Size);
        }

        [Fact]
        public void CountShouldStartAtZero()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.DataEmptySize3Mock);
            Assert.Equal(0, circleMinHeap.Count);
        }

        [Fact]
        public void CountShouldStartAtConstructorInputCount()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data1EntryWithSize2Mock);
            Assert.Equal(1, circleMinHeap.Count);

            circleMinHeap = new CircleMinHeap<char>(circleMinHeap);
            Assert.Equal(1, circleMinHeap.Count);
        }

        [Fact]
        public void CountShouldIncrementWhenPushAdds()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data2EntriesWithSize3Mock);
            circleMinHeap.Push('b', 20);

            Assert.Equal(3, circleMinHeap.Count);
        }

        [Fact]
        public void CountShouldNotIncrementWhenPushDoesNotAdd()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Push('d', 9999);

            Assert.Equal(3, circleMinHeap.Count);
        }

        [Fact]
        public void PopShouldDecrementCount()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data2EntriesWithSize3Mock);
            circleMinHeap.Pop();

            Assert.Equal(1, circleMinHeap.Count);
        }

        [Fact]
        public void PopShouldRemoveElementAtPointer()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Pop();

            Assert.Equal(2, circleMinHeap.Count);
            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[0].Value, circleMinHeap._data[0].Value);
            Assert.Equal(CircleMinHeapMocks.Data3EntriesWithSize3Mock[2].Value, circleMinHeap._data[1].Value);
        }

        [Fact]
        public void RotateShouldIncrementPointerPosition()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            for (int i = 0; i <= CircleMinHeapMocks.Data3EntriesWithSize3Mock.Length; i++)
            {
                Assert.Equal(i, circleMinHeap.Pointer);
                circleMinHeap.Rotate();
            }
            Assert.Equal(0, circleMinHeap.Pointer);
        }

        [Fact]
        public void ResetShouldSetPointerToZero()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();
            circleMinHeap.Reset();

            Assert.Equal(0, circleMinHeap.Pointer);
        }

        [Fact]
        public void PeekShouldReturnElementAtPointer()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();

            Assert.Equal(CircleMinHeapMocks.Data26EntriesWithSize26Mock[3].Value, circleMinHeap.Peek());
            circleMinHeap.Reset();
            Assert.Equal(CircleMinHeapMocks.Data26EntriesWithSize26Mock[0].Value, circleMinHeap.Peek());
        }

        [Fact]
        public void PopShouldReturnSameElementAsPeek()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();
            circleMinHeap.Rotate();

            Assert.Equal(circleMinHeap.Peek(), circleMinHeap.Pop());
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsPresent()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            Assert.True(circleMinHeap.Contains('q'));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotPresent()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            Assert.False(circleMinHeap.Contains('Q'));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfIndexedElementIsPresent()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            Assert.True(circleMinHeap.Contains(
                CircleMinHeapMocks.Data26EntriesWithSize26Mock[16].Value, CircleMinHeapMocks.Data26EntriesWithSize26Mock[16].Index));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfIndexedElementIsNotPresent()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            Assert.False(circleMinHeap.Contains('Q', 1700));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfCombinedIndexedElementIsPresent()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            Assert.True(circleMinHeap.Contains(new HeapEntry<char>(
                CircleMinHeapMocks.Data26EntriesWithSize26Mock[16].Index,
                CircleMinHeapMocks.Data26EntriesWithSize26Mock[16].Value)));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfCombinedIndexedElementIsNotPresent()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            Assert.False(circleMinHeap.Contains(new HeapEntry<char>(1700, 'Q')));
        }

        [Fact]
        public void MergeShouldCombineElementsFromTwocircleMinHeaps()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize5Mock);
            circleMinHeap.Merge(new CircleMinHeap<char>(CircleMinHeapMocks.Data2EntriesWithSize3Mock));

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
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data3EntriesWithSize3Mock);
            circleMinHeap.Merge(new CircleMinHeap<char>(CircleMinHeapMocks.Data2EntriesWithSize3Mock));

            Assert.Equal(3, circleMinHeap.Count);
            Assert.Equal('a', circleMinHeap._data[0].Value);
            Assert.Equal('a', circleMinHeap._data[1].Value);
            Assert.Equal('b', circleMinHeap._data[2].Value);
        }

        [Fact]
        public void DataArrayShouldBeTraversibleInOrder()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);

            int i = 0;
            foreach (char c in circleMinHeap) { Assert.Equal(circleMinHeap._data[i++].Value, c); }
        }

        [Fact]
        public void DataArrayShouldBeAccessibleViaIndexer()
        {
            ICircleHeap<char> circleMinHeap = new CircleMinHeap<char>(CircleMinHeapMocks.Data26EntriesWithSize26Mock);
            for (int i = 0; i < circleMinHeap.Count; i++)
            {
                Assert.Equal(circleMinHeap._data[i].Value, circleMinHeap[i]);
            }
        }
    }
}
