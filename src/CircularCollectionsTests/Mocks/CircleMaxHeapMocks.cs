using Collections.Generic.Circular;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircularTests.Mocks
{
    public static class CircleMaxHeapMocks
    {
        public static IHeapEntry<char>[] DataEmptySize1Mock { get; set; }
            = new HeapEntry<char>[1];
        public static IHeapEntry<char>[] DataEmptySize3Mock { get; set; }
            = new HeapEntry<char>[3];
        public static IHeapEntry<char>[] Data1EntryWithSize2Mock { get; set; }
            = new HeapEntry<char>[2] { new HeapEntry<char>(10, 'a'), null };
        public static IHeapEntry<char>[] Data2EntriesWithSize3Mock { get; set; }
            = new HeapEntry<char>[3] { new HeapEntry<char>(10, 'a'), new HeapEntry<char>(5, 'c'), null };
        public static IHeapEntry<char>[] Data3EntriesWithSize3Mock { get; set; }
            = new HeapEntry<char>[3] { new HeapEntry<char>(10, 'a'), new HeapEntry<char>(8, 'b'), new HeapEntry<char>(5, 'c') };
        public static IHeapEntry<char>[] Data3EntriesWithSize5Mock { get; set; }
            = new HeapEntry<char>[5]
            {
                new HeapEntry<char>(10, 'a'), new HeapEntry<char>(8, 'b'), new HeapEntry<char>(5, 'c'), null, null
            };
        public static IHeapEntry<char>[] Data26EntriesWithSize26Mock { get; set; }
            = new HeapEntry<char>[26]
            {
                new HeapEntry<char>(2600, 'a'), new HeapEntry<char>(2500, 'b'), new HeapEntry<char>(2400, 'c'),
                new HeapEntry<char>(2300, 'd'), new HeapEntry<char>(2200, 'e'), new HeapEntry<char>(2100, 'f'),
                new HeapEntry<char>(2000, 'g'), new HeapEntry<char>(1900, 'h'), new HeapEntry<char>(1800, 'i'),
                new HeapEntry<char>(1700, 'j'), new HeapEntry<char>(1600, 'k'), new HeapEntry<char>(1500, 'l'),
                new HeapEntry<char>(1400, 'm'), new HeapEntry<char>(1300, 'n'), new HeapEntry<char>(1200, 'o'),
                new HeapEntry<char>(1100, 'p'), new HeapEntry<char>(1000, 'q'), new HeapEntry<char>(900, 'r'),
                new HeapEntry<char>(800, 's'), new HeapEntry<char>(700, 't'), new HeapEntry<char>(600, 'u'),
                new HeapEntry<char>(500, 'v'), new HeapEntry<char>(400, 'w'), new HeapEntry<char>(300, 'x'),
                new HeapEntry<char>(200, 'y'), new HeapEntry<char>(100, 'z')
            };
    }
}
