using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Mocks.Abstracts
{
    public abstract class ACircleQueueAndStackMocks : ICircleQueueAndStackMocks
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
            = new char[2] { default, 'a' };
        object ICircleContainerMocks.Data1EntryWithSize2Mock
        {
            get { return Data1EntryWithSize2Mock; }
            set { }
        }

        public char[] Data2EntriesWithSize3Mock { get; set; }
            = new char[3] { default, 'a', 'c' };
        object ICircleContainerMocks.Data2EntriesWithSize3Mock
        {
            get { return Data2EntriesWithSize3Mock; }
            set { }
        }

        public char[] Data3EntriesWithSize3Mock { get; set; }
            = new char[3] { 'c', 'a', 'b' };
        object ICircleContainerMocks.Data3EntriesWithSize3Mock
        {
            get { return Data3EntriesWithSize3Mock; }
            set { }
        }

        public char[] Data3EntriesWithSize5Mock { get; set; }
            = new char[5]
            {
                default, 'a', 'b', 'c', default
            };
        object ICircleContainerMocks.Data3EntriesWithSize5Mock
        {
            get { return Data3EntriesWithSize5Mock; }
            set { }
        }

        public char[] Data26EntriesWithSize26Mock { get; set; }
            = new char[26]
            {
                'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y'
            };
        object ICircleContainerMocks.Data26EntriesWithSize26Mock
        {
            get { return Data26EntriesWithSize26Mock; }
            set { }
        }
    }
}
