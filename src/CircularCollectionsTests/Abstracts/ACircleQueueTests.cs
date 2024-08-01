using Collections.Generic.Circular;
using Collections.Generic.CircularTests.Interfaces;
using Collections.Generic.CircularTests.Mocks;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Data;
using Xunit;

namespace Collections.Generic.CircularTests.Abstracts
{
    public abstract class ACircleQueueTests : ICircleQueueTests
    {
        public abstract ICircleQueueAndStackMocks Mocks { get; set; }

        public abstract ICircleQueue<char> TestSetup(char[] mock, bool indexerIsReadOnly = true);

        // This is necessary because covariant return types are not yet supported in C#
        object ICircleQueueTests.TestSetup(object mock, bool indexerIsReadOnly) => TestSetup((char[])mock, indexerIsReadOnly);

        [Fact]
        public void EnqueueShouldAddInitialElement()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.DataEmptySize1Mock);
            circleQueue.Enqueue('0');

            Assert.Equal('0', circleQueue._data[0]);
        }

        [Fact]
        public void EnqueueToPartiallyFilledShouldAdd()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data1EntryWithSize2Mock);
            circleQueue.Enqueue('0');

            Assert.Equal(((char[])Mocks.Data1EntryWithSize2Mock)[1], circleQueue._data[1]);
            Assert.Equal('0', circleQueue._data[0]);
        }

        [Fact]
        public void EnqueueToFullShouldReplace()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock);
            circleQueue.Enqueue('0');

            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[0], circleQueue._data[0]);
            Assert.Equal('0', circleQueue._data[1]); // Note - Queues and stacks start at index 1
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[2], circleQueue._data[2]);
        }

        [Fact]
        public void DequeueShouldRemoveFirstIn()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock);
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[1], circleQueue.Dequeue());
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[2], circleQueue.Dequeue());
            Assert.Equal(((char[])Mocks.Data3EntriesWithSize3Mock)[0], circleQueue.Dequeue()); // Index 0 is last element added
        }

        [Fact]
        public void RotateShouldIncrementPointerPosition()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock);
            for (int i = 1; i < (((char[])Mocks.Data3EntriesWithSize3Mock).Length * 3); i++) // Index starts at 1 initially
            {
                Assert.Equal(i % ((char[])Mocks.Data3EntriesWithSize3Mock).Length, circleQueue.Pointer);
                circleQueue.Rotate();
            }
            Assert.Equal(0, circleQueue.Pointer);
        }

        [Fact]
        public void SizeShouldEqualConstructorInputDataLength()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.DataEmptySize3Mock);
            Assert.Equal(((char[])Mocks.DataEmptySize3Mock).Length, circleQueue.Size);
        }

        [Fact]
        public void SizeShouldEqualDataLength()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.DataEmptySize3Mock);
            Assert.Equal(circleQueue._data.Length, circleQueue.Size);
        }

        [Fact]
        public void CountShouldStartAtZero()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.DataEmptySize3Mock);
            Assert.Equal(0, circleQueue.Count);
        }

        [Fact]
        public void CountShouldStartAtConstructorInputCount()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data1EntryWithSize2Mock);
            Assert.Equal(1, circleQueue.Count);

            circleQueue = new CircleQueue<char>(circleQueue);
            Assert.Equal(1, circleQueue.Count);
        }

        [Fact]
        public void PeekShouldReturnElementAtPointer()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);

            Assert.Equal(((char[])Mocks.Data26EntriesWithSize26Mock)[1], circleQueue.Peek());
            circleQueue.Rotate();
            circleQueue.Rotate();
            circleQueue.Rotate();
            Assert.Equal(((char[])Mocks.Data26EntriesWithSize26Mock)[4], circleQueue.Peek());
            circleQueue.Rotate();
            Assert.Equal(((char[])Mocks.Data26EntriesWithSize26Mock)[5], circleQueue.Peek());
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsPresent()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            Assert.True(circleQueue.Contains('q'));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotPresent()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            Assert.False(circleQueue.Contains('Q'));
        }

        [Fact]
        public void DataArrayShouldBeTraversibleInOrder()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);

            int i = 1;
            foreach (char c in circleQueue)
            {
                Assert.Equal(circleQueue._data[i], c);
                i = (++i) % circleQueue._data.Length;
            }
        }

        [Fact]
        public void DataArrayShouldBeAccessibleViaIndexer()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data26EntriesWithSize26Mock);
            for (int i = 0; i < circleQueue.Count; i++)
            {
                Assert.Equal(circleQueue._data[i], circleQueue[i]);
            }
        }

        [Fact]
        public void DataArrayShouldNotBeWritableViaIndexerIfReadOnly()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock, indexerIsReadOnly: true);

            void act() => circleQueue[0] = ' ';

            Assert.Equal("Indexer is set to read-only.",
                Assert.Throws<ReadOnlyException>(act).Message);
        }

        [Fact]
        public void DataArrayShouldBeWritableViaIndexerIfNotReadOnly()
        {
            ICircleQueue<char> circleQueue = TestSetup((char[])Mocks.Data3EntriesWithSize3Mock, indexerIsReadOnly: false);

            circleQueue[0] = ' ';
            Assert.Equal(' ', circleQueue[0]);
        }
    }
}
