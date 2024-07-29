using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using Xunit;

namespace Collections.Generic.CircularTests.Abstracts
{
    public abstract class ACircleHeapTests : ICircleHeapTests
    {
        public abstract ICircleHeapMocks Mocks { get; set; }

        public abstract ICircleHeap<char> TestSetup(IHeapEntry<char>[] mock);

        // This is necessary because covariant return types are not yet supported in C#
        object ICircleContainerTests.TestSetup(object mock) => TestSetup((IHeapEntry<char>[])mock);

        public abstract void PeekShouldReturnElementAtPointer();

        [Fact]
        public void PushShouldAddInitialElement()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.DataEmptySize1Mock);
            circleHeap.Push('a', 10);

            Assert.Equal('a', circleHeap._data[0].Value);
        }

        [Fact]
        public void PointerShouldStartAtTop()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            Assert.Equal(circleHeap.Top, circleHeap._data[circleHeap.Pointer].Value);
        }

        [Fact]
        public void TopShouldPointToElementAtIndexZero()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            Assert.Equal(circleHeap._data[0].Value, circleHeap.Top);
        }

        [Fact]
        public void SizeShouldEqualConstructorInputDataLength()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.DataEmptySize3Mock);
            Assert.Equal(((IHeapEntry<char>[])Mocks.DataEmptySize3Mock).Length, circleHeap.Size);
        }

        [Fact]
        public void SizeShouldEqualDataLength()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.DataEmptySize3Mock);
            Assert.Equal(circleHeap._data.Length, circleHeap.Size);
        }

        [Fact]
        public void CountShouldStartAtZero()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.DataEmptySize3Mock);
            Assert.Equal(0, circleHeap.Count);
        }

        [Fact]
        public void CountShouldStartAtConstructorInputCount()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data1EntryWithSize2Mock);
            Assert.Equal(1, circleHeap.Count);

            circleHeap = new CircleMaxHeap<char>(circleHeap);
            Assert.Equal(1, circleHeap.Count);
        }

        [Fact]
        public void CountShouldIncrementWhenPushAdds()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock);
            circleHeap.Push('b', 8);

            Assert.Equal(3, circleHeap.Count);
        }

        [Fact]
        public void CountShouldNotIncrementWhenPushDoesNotAdd()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            circleHeap.Push('d', 1);

            Assert.Equal(3, circleHeap.Count);
        }

        [Fact]
        public void PopShouldDecrementCount()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data2EntriesWithSize3Mock);
            circleHeap.Pop();

            Assert.Equal(1, circleHeap.Count);
        }

        [Fact]
        public void RotateShouldIncrementPointerPosition()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock);
            for (int i = 0; i < (((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock).Length * 3); i++)
            {
                Assert.Equal(i % ((IHeapEntry<char>[])Mocks.Data3EntriesWithSize3Mock).Length, circleHeap.Pointer);
                circleHeap.Rotate();
            }
            Assert.Equal(0, circleHeap.Pointer);
        }

        [Fact]
        public void ResetShouldSetPointerToZero()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            circleHeap.Rotate();
            circleHeap.Rotate();
            circleHeap.Rotate();
            circleHeap.Reset();

            Assert.Equal(0, circleHeap.Pointer);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsPresent()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            Assert.True(circleHeap.Contains('q'));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotPresent()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            Assert.False(circleHeap.Contains('Q'));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfIndexedElementIsPresent()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            Assert.True(circleHeap.Contains(
                ((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock)[16].Value,
                ((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock)[16].Index));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfIndexedElementIsNotPresent()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            Assert.False(circleHeap.Contains('Q', 1700));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfCombinedIndexedElementIsPresent()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            Assert.True(circleHeap.Contains(new HeapEntry<char>(
                ((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock)[16].Index,
                ((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock)[16].Value)));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfCombinedIndexedElementIsNotPresent()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            Assert.False(circleHeap.Contains(new HeapEntry<char>(1700, 'Q')));
        }

        [Fact]
        public void DataArrayShouldBeTraversibleInOrder()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);

            int i = 0;
            foreach (char c in circleHeap) { Assert.Equal(circleHeap._data[i++].Value, c); }
        }

        [Fact]
        public void DataArrayShouldBeAccessibleViaIndexer()
        {
            ICircleHeap<char> circleHeap = TestSetup((IHeapEntry<char>[])Mocks.Data26EntriesWithSize26Mock);
            for (int i = 0; i < circleHeap.Count; i++)
            {
                Assert.Equal(circleHeap._data[i].Value, circleHeap[i]);
            }
        }
    }
}
