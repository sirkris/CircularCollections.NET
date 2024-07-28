using Collections.Generic.CircularTests.Mocks.Interfaces;
using Collections.Generic.Circular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Mocks
{
    public class CircleQueueMocks : ICircleQueueMocks
    {
        public char[] DataEmptySize1Mock { get; set; }
            = new char[1];
        object ICircleContainerMocks.DataEmptySize1Mock
        {
            get { return DataEmptySize1Mock; }
            set { }
        }

        public char[] DataEmptySize3Mock { get; set; }
            = new char[3];
        object ICircleContainerMocks.DataEmptySize3Mock
        {
            get { return DataEmptySize3Mock; }
            set { }
        }

        public char[] Data1EntryWithSize2Mock { get; set; }
            = new char[2] { 'a', default };
        object ICircleContainerMocks.Data1EntryWithSize2Mock
        {
            get { return Data1EntryWithSize2Mock; }
            set { }
        }

        public char[] Data2EntriesWithSize3Mock { get; set; }
            = new char[3] { 'a', 'c', default };
        object ICircleContainerMocks.Data2EntriesWithSize3Mock
        {
            get { return Data2EntriesWithSize3Mock; }
            set { }
        }

        public char[] Data3EntriesWithSize3Mock { get; set; }
            = new char[3] { 'a', 'b', 'c' };
        object ICircleContainerMocks.Data3EntriesWithSize3Mock
        {
            get { return Data3EntriesWithSize3Mock; }
            set { }
        }

        public char[] Data3EntriesWithSize5Mock { get; set; }
            = new char[5]
            {
                'a', 'b', 'c', default, default
            };
        object ICircleContainerMocks.Data3EntriesWithSize5Mock
        {
            get { return Data3EntriesWithSize5Mock; }
            set { }
        }

        public char[] Data26EntriesWithSize26Mock { get; set; }
            = new char[26]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
        object ICircleContainerMocks.Data26EntriesWithSize26Mock
        {
            get { return Data26EntriesWithSize26Mock; }
            set { }
        }
    }
}
