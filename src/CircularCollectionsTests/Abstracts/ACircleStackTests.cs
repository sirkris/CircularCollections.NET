using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Data;
using Xunit;

namespace Collections.Generic.CircularTests.Abstracts
{
    public abstract class ACircleStackTests : ICircleStackTests
    {
        public abstract ICircleQueueAndStackMocks Mocks { get; set; }

        public abstract ICircleStack<char> TestSetup(char[] mock, bool indexerIsReadOnly = true);

        // This is necessary because covariant return types are not yet supported in C#
        object ICircleStackTests.TestSetup(object mock, bool indexerIsReadOnly) => TestSetup((char[])mock, indexerIsReadOnly);

        [Fact]
        public void PushShouldAddInitialElement()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.DataEmptySize1Mock);
            circleStack.Push('0');

            Assert.Equal('0', circleStack._data[0]);
        }

        [Fact]
        public void PushToPartiallyFilledShouldAdd()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data1EntryWithSize2Mock);
            circleStack.Push('0');

            Assert.Equal(((char[])Mocks.Data1EntryWithSize2Mock)[1], circleStack._data[1]);
            Assert.Equal('0', circleStack._data[0]);
        }

        [Fact]
        public void PushToFullShouldReplace()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock);
            circleStack.Push('0');

            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[0], circleStack._data[0]);
            Assert.Equal('0', circleStack._data[1]); // Note - Queues and stacks start at index 1
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[2], circleStack._data[2]);
        }

        [Fact]
        public void PopShouldRemoveLastIn()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock);
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[0], circleStack.Pop()); // Index 0 is last element added
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[2], circleStack.Pop());
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[1], circleStack.Pop());
        }

        [Fact]
        public void RotateShouldDecrementPointerPosition()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock);
            int pos = 0; // Mock data array is full so pointer is at last element, which is index 0
            for (int i = 0; i < (((char[])Mocks.Data3EntriesWithSize3Mock).Length * 3); i++)
            {
                Assert.Equal(pos, circleStack.Pointer);
                circleStack.Rotate();
                if ((--pos).Equals(-1)) { pos = (circleStack.Size - 1); }
            }
            Assert.Equal(0, circleStack.Pointer);
        }

        [Fact]
        public void RotateShouldApplySpecifiedRotationFactor()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            Assert.Equal(0, circleStack.Pointer);

            circleStack.Rotate(factor: 10);
            Assert.Equal(10, circleStack.Pointer);
            circleStack.Rotate(factor: -10);
            Assert.Equal(0, circleStack.Pointer);

            circleStack.Rotate(factor: ((char[])Mocks.Data26EntriesWithSize26Mock).Length * 2);
            Assert.Equal(0, circleStack.Pointer);
            circleStack.Rotate(factor: ((char[])Mocks.Data26EntriesWithSize26Mock).Length * -2);
            Assert.Equal(0, circleStack.Pointer);
        }

        [Fact]
        public void SizeShouldEqualConstructorInputDataLength()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.DataEmptySize3Mock);
            Assert.Equal(((char[])Mocks.DataEmptySize3Mock).Length, circleStack.Size);
        }

        [Fact]
        public void SizeShouldEqualDataLength()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.DataEmptySize3Mock);
            Assert.Equal(circleStack._data.Length, circleStack.Size);
        }

        [Fact]
        public void CountShouldStartAtZero()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.DataEmptySize3Mock);
            Assert.Equal(0, circleStack.Count);
        }

        [Fact]
        public void CountShouldStartAtConstructorInputCount()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data1EntryWithSize2Mock);
            Assert.Equal(1, circleStack.Count);

            circleStack = new CircleStack<char>(circleStack);
            Assert.Equal(1, circleStack.Count);
        }

        [Fact]
        public void PeekShouldReturnElementAtPointer()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);

            Assert.Equal(((char[])Mocks.Data26EntriesWithSize26Mock)[0], circleStack.Peek());
            circleStack.Rotate();
            circleStack.Rotate();
            circleStack.Rotate();
            Assert.Equal(((char[])Mocks.Data26EntriesWithSize26Mock)[^3], 
                circleStack.Peek());
            circleStack.Rotate();
            Assert.Equal(((char[])Mocks.Data26EntriesWithSize26Mock)[^4],
                circleStack.Peek());
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsPresent()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            Assert.True(circleStack.Contains('q'));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotPresent()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            Assert.False(circleStack.Contains('Q'));
        }

        [Fact]
        public void DataArrayShouldBeTraversibleInOrder()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);

            // Note - Stack foreach traverses from pointer in reverse order
            int i = 0; // Mock data array is full so pointer will be at the last element added, which is index 0
            foreach (char c in circleStack)
            {
                Assert.Equal(circleStack._data[i], c);
                if ((--i).Equals(-1)) { i = (circleStack.Size - 1); }
            }
        }

        [Fact]
        public void DataArrayShouldBeAccessibleViaIndexer()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            for (int i = 0; i < circleStack.Count; i++)
            {
                Assert.Equal(circleStack._data[i], circleStack[i]);
            }
        }

        [Fact]
        public void DataArrayShouldNotBeWritableViaIndexerIfReadOnly()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock, indexerIsReadOnly: true);

            void act() => circleStack[0] = ' ';

            Assert.Equal("Indexer is set to read-only.",
                Assert.Throws<ReadOnlyException>(act).Message);
        }

        [Fact]
        public void DataArrayShouldBeWritableViaIndexerIfNotReadOnly()
        {
            ICircleStack<char> circleStack = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock, indexerIsReadOnly: false);

            circleStack[0] = ' ';
            Assert.Equal(' ', circleStack[0]);
        }
    }
}
