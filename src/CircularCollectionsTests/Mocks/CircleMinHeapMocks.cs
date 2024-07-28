using Collections.Generic.CircularTests.Mocks.Interfaces;
using Collections.Generic.Circular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Mocks
{
    public class CircleMinHeapMocks : ICircleHeapMocks
    {
        public IHeapEntry<char>[] DataEmptySize1Mock { get; set; }
            = new HeapEntry<char>[1];
        object[] ICircleContainerMocks.DataEmptySize1Mock
        {
            get { return DataEmptySize1Mock; }
            set { }
        }

        public IHeapEntry<char>[] DataEmptySize3Mock { get; set; }
            = new HeapEntry<char>[3];
        object[] ICircleContainerMocks.DataEmptySize3Mock
        {
            get { return DataEmptySize3Mock; }
            set { }
        }

        public IHeapEntry<char>[] Data1EntryWithSize2Mock { get; set; }
            = new HeapEntry<char>[2] { new HeapEntry<char>(10, 'a'), null };
        object[] ICircleContainerMocks.Data1EntryWithSize2Mock
        {
            get { return Data1EntryWithSize2Mock; }
            set { }
        }

        public IHeapEntry<char>[] Data2EntriesWithSize3Mock { get; set; }
            = new HeapEntry<char>[3] { new HeapEntry<char>(5, 'a'), new HeapEntry<char>(10, 'c'), null };
        object[] ICircleContainerMocks.Data2EntriesWithSize3Mock
        {
            get { return Data2EntriesWithSize3Mock; }
            set { }
        }

        public IHeapEntry<char>[] Data3EntriesWithSize3Mock { get; set; }
            = new HeapEntry<char>[3] { new HeapEntry<char>(5, 'a'), new HeapEntry<char>(8, 'b'), new HeapEntry<char>(10, 'c') };
        object[] ICircleContainerMocks.Data3EntriesWithSize3Mock
        {
            get { return Data3EntriesWithSize3Mock; }
            set { }
        }

        public IHeapEntry<char>[] Data3EntriesWithSize5Mock { get; set; }
            = new HeapEntry<char>[5]
            {
                new HeapEntry<char>(5, 'a'), new HeapEntry<char>(8, 'b'), new HeapEntry<char>(10, 'c'), null, null
            };
        object[] ICircleContainerMocks.Data3EntriesWithSize5Mock
        {
            get { return Data3EntriesWithSize5Mock; }
            set { }
        }

        public IHeapEntry<char>[] Data26EntriesWithSize26Mock { get; set; }
            = new HeapEntry<char>[26]
            {
                new HeapEntry<char>(100, 'a'), new HeapEntry<char>(200, 'b'), new HeapEntry<char>(300, 'c'),
                new HeapEntry<char>(400, 'd'), new HeapEntry<char>(500, 'e'), new HeapEntry<char>(600, 'f'),
                new HeapEntry<char>(700, 'g'), new HeapEntry<char>(800, 'h'), new HeapEntry<char>(900, 'i'),
                new HeapEntry<char>(1000, 'j'), new HeapEntry<char>(1100, 'k'), new HeapEntry<char>(1200, 'l'),
                new HeapEntry<char>(1300, 'm'), new HeapEntry<char>(1400, 'n'), new HeapEntry<char>(1500, 'o'),
                new HeapEntry<char>(1600, 'p'), new HeapEntry<char>(1700, 'q'), new HeapEntry<char>(1800, 'r'),
                new HeapEntry<char>(1900, 's'), new HeapEntry<char>(2000, 't'), new HeapEntry<char>(2100, 'u'),
                new HeapEntry<char>(2200, 'v'), new HeapEntry<char>(2300, 'w'), new HeapEntry<char>(2400, 'x'),
                new HeapEntry<char>(2500, 'y'), new HeapEntry<char>(2600, 'z')
            };
        object[] ICircleContainerMocks.Data26EntriesWithSize26Mock
        {
            get { return Data26EntriesWithSize26Mock; }
            set { }
        }
    }
}
