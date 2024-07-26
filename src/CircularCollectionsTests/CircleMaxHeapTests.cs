using Collections.Generic.Circular;
using CircularTests.Mocks;
using System;
using Xunit;

namespace Collections.Generic.CircularTests
{
    public class CircleMaxHeapTests
    {
        [Fact]
        public void PushShouldAddInitialElement()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.DataEmptySize1Mock);
            circleMaxHeap.Push('a', 10);

            Assert.Equal('a', circleMaxHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddHigherIndexElementToTop()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data1EntryWithSize2Mock);
            circleMaxHeap.Push('0', 20);

            Assert.Equal('0', circleMaxHeap._data[0].Value);
            Assert.Equal(CircleMaxHeapMocks.Data1EntryWithSize2Mock[0].Value, circleMaxHeap._data[1].Value);
        }

        [Fact]
        public void PushShouldAddLowerIndexElementToBottom()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data1EntryWithSize2Mock);
            circleMaxHeap.Push('b', 5);

            Assert.Equal('b', circleMaxHeap._data[1].Value);
            Assert.Equal(CircleMaxHeapMocks.Data1EntryWithSize2Mock[0].Value, circleMaxHeap._data[0].Value);
        }

        [Fact]
        public void PushShouldAddMidIndexElementToMiddle()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data2EntriesWithSize3Mock);
            circleMaxHeap.Push('b', 8);

            Assert.Equal(CircleMaxHeapMocks.Data2EntriesWithSize3Mock[0].Value, circleMaxHeap._data[0].Value);
            Assert.Equal('b', circleMaxHeap._data[1].Value);
            Assert.Equal(CircleMaxHeapMocks.Data2EntriesWithSize3Mock[1].Value, circleMaxHeap._data[2].Value);
        }

        [Fact]
        public void PushLowToFullShouldLeaveUnchanged()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            circleMaxHeap.Push('d', 1);

            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[0].Value, circleMaxHeap._data[0].Value);
            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[1].Value, circleMaxHeap._data[1].Value);
            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[2].Value, circleMaxHeap._data[2].Value);
        }

        [Fact]
        public void PushToFullShouldOverwriteLowestValue()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            circleMaxHeap.Push('0', 20);

            Assert.Equal('0', circleMaxHeap._data[0].Value);
            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[0].Value, circleMaxHeap._data[1].Value);
            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[1].Value, circleMaxHeap._data[2].Value);
        }

        [Fact]
        public void PointerShouldStartAtTop()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            Assert.Equal(circleMaxHeap.Top, circleMaxHeap._data[circleMaxHeap.Pointer].Value);
        }

        [Fact]
        public void TopShouldPointToElementAtIndexZero()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            Assert.Equal(circleMaxHeap._data[0].Value, circleMaxHeap.Top);
        }

        [Fact]
        public void BottomShouldPointToElementAtLastFilledIndex()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.DataEmptySize3Mock);
            circleMaxHeap.Push('b', 10);
            circleMaxHeap.Push('a', 20);

            Assert.Equal('a', circleMaxHeap._data[0].Value);
            Assert.Equal('b', circleMaxHeap._data[1].Value);
            Assert.Equal(circleMaxHeap._data[1].Value, circleMaxHeap.Bottom);
        }

        [Fact]
        public void SizeShouldEqualConstructorInputDataLength()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.DataEmptySize3Mock);
            Assert.Equal(CircleMaxHeapMocks.DataEmptySize3Mock.Length, circleMaxHeap.Size);
        }

        [Fact]
        public void SizeShouldEqualDataLength()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.DataEmptySize3Mock);
            Assert.Equal(circleMaxHeap._data.Length, circleMaxHeap.Size);
        }

        [Fact]
        public void CountShouldStartAtZero()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.DataEmptySize3Mock);
            Assert.Equal(0, circleMaxHeap.Count);
        }

        [Fact]
        public void CountShouldStartAtConstructorInputCount()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data1EntryWithSize2Mock);
            Assert.Equal(1, circleMaxHeap.Count);

            circleMaxHeap = new CircleMaxHeap<char>(circleMaxHeap);
            Assert.Equal(1, circleMaxHeap.Count);
        }

        [Fact]
        public void CountShouldIncrementWhenPushAdds()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data2EntriesWithSize3Mock);
            circleMaxHeap.Push('b', 8);

            Assert.Equal(3, circleMaxHeap.Count);
        }

        [Fact]
        public void CountShouldNotIncrementWhenPushDoesNotAdd()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            circleMaxHeap.Push('d', 1);

            Assert.Equal(3, circleMaxHeap.Count);
        }

        [Fact]
        public void PopShouldDecrementCount()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data2EntriesWithSize3Mock);
            circleMaxHeap.Pop();

            Assert.Equal(1, circleMaxHeap.Count);
        }

        [Fact]
        public void PopShouldRemoveElementAtPointer()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            circleMaxHeap.Rotate();
            circleMaxHeap.Pop();

            Assert.Equal(2, circleMaxHeap.Count);
            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[0].Value, circleMaxHeap._data[0].Value);
            Assert.Equal(CircleMaxHeapMocks.Data3EntriesWithSize3Mock[2].Value, circleMaxHeap._data[1].Value);
        }

        [Fact]
        public void RotateShouldIncrementPointerPosition()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            for (int i = 0; i < CircleMaxHeapMocks.Data3EntriesWithSize3Mock.Length; i++)
            {
                Assert.Equal(i, circleMaxHeap.Pointer);
                circleMaxHeap.Rotate();
            }
            Assert.Equal(0, circleMaxHeap.Pointer);
        }

        [Fact]
        public void ResetShouldSetPointerToZero()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            circleMaxHeap.Rotate();
            circleMaxHeap.Rotate();
            circleMaxHeap.Rotate();
            circleMaxHeap.Reset();

            Assert.Equal(0, circleMaxHeap.Pointer);
        }

        [Fact]
        public void PeekShouldReturnElementAtPointer()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            circleMaxHeap.Rotate();
            circleMaxHeap.Rotate();
            circleMaxHeap.Rotate();

            Assert.Equal(CircleMaxHeapMocks.Data26EntriesWithSize26Mock[3].Value, circleMaxHeap.Peek());
            circleMaxHeap.Reset();
            Assert.Equal(CircleMaxHeapMocks.Data26EntriesWithSize26Mock[0].Value, circleMaxHeap.Peek());
        }

        [Fact]
        public void PopShouldReturnSameElementAsPeek()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            circleMaxHeap.Rotate();
            circleMaxHeap.Rotate();
            circleMaxHeap.Rotate();

            Assert.Equal(circleMaxHeap.Peek(), circleMaxHeap.Pop());
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsPresent()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            Assert.True(circleMaxHeap.Contains('q'));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotPresent()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            Assert.False(circleMaxHeap.Contains('Q'));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfIndexedElementIsPresent()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            Assert.True(circleMaxHeap.Contains(
                CircleMaxHeapMocks.Data26EntriesWithSize26Mock[16].Value, CircleMaxHeapMocks.Data26EntriesWithSize26Mock[16].Index));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfIndexedElementIsNotPresent()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            Assert.False(circleMaxHeap.Contains('Q', 1700));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfCombinedIndexedElementIsPresent()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            Assert.True(circleMaxHeap.Contains(new HeapEntry<char>(
                CircleMaxHeapMocks.Data26EntriesWithSize26Mock[16].Index,
                CircleMaxHeapMocks.Data26EntriesWithSize26Mock[16].Value)));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfCombinedIndexedElementIsNotPresent()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            Assert.False(circleMaxHeap.Contains(new HeapEntry<char>(1700, 'Q')));
        }

        [Fact]
        public void MergeShouldCombineElementsFromTwoCircleMaxHeaps()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize5Mock);
            circleMaxHeap.Merge(new CircleMaxHeap<char>(CircleMaxHeapMocks.Data2EntriesWithSize3Mock));

            Assert.Equal(5, circleMaxHeap.Count);
            Assert.Equal('a', circleMaxHeap._data[0].Value);
            Assert.Equal('a', circleMaxHeap._data[1].Value);
            Assert.Equal('b', circleMaxHeap._data[2].Value);
            Assert.Equal('c', circleMaxHeap._data[3].Value);
            Assert.Equal('c', circleMaxHeap._data[4].Value);
        }

        [Fact]
        public void MergeShouldCombineMaxElementsFromTwoCircleMaxHeaps()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data3EntriesWithSize3Mock);
            circleMaxHeap.Merge(new CircleMaxHeap<char>(CircleMaxHeapMocks.Data2EntriesWithSize3Mock));

            Assert.Equal(3, circleMaxHeap.Count);
            Assert.Equal('a', circleMaxHeap._data[0].Value);
            Assert.Equal('a', circleMaxHeap._data[1].Value);
            Assert.Equal('b', circleMaxHeap._data[2].Value);
        }

        [Fact]
        public void DataArrayShouldBeTraversibleInOrder()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);

            int i = 0;
            foreach (char c in circleMaxHeap) { Assert.Equal(circleMaxHeap._data[i++].Value, c); }
        }

        [Fact]
        public void DataArrayShouldBeAccessibleViaIndexer()
        {
            ICircleHeap<char> circleMaxHeap = new CircleMaxHeap<char>(CircleMaxHeapMocks.Data26EntriesWithSize26Mock);
            for (int i = 0; i < circleMaxHeap.Count; i++)
            {
                Assert.Equal(circleMaxHeap._data[i].Value, circleMaxHeap[i]);
            }
        }
    }
}
