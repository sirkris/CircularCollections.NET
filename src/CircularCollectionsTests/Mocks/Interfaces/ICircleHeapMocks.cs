using Collections.Generic.Circular;

namespace Collections.Generic.CircularTests.Mocks.Interfaces
{
    public interface ICircleHeapMocks
    {
        public IHeapEntry<char>[] DataEmptySize1Mock { get; set; }
        public IHeapEntry<char>[] DataEmptySize3Mock { get; set; }
        public IHeapEntry<char>[] Data1EntryWithSize2Mock { get; set; }
        public IHeapEntry<char>[] Data2EntriesWithSize3Mock { get; set; }
        public IHeapEntry<char>[] Data3EntriesWithSize3Mock { get; set; }
        public IHeapEntry<char>[] Data3EntriesWithSize5Mock { get; set; }
        public IHeapEntry<char>[] Data26EntriesWithSize26Mock { get; set; }
    }
}
