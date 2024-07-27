using System;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleContainerTests
    {
        public ICircleHeapMocks Mocks { get; set; }

        public object TestSetup(object[] mock);

        public void SizeShouldEqualConstructorInputDataLength();
        public void SizeShouldEqualDataLength();
        public void CountShouldStartAtZero();
        public void CountShouldStartAtConstructorInputCount();
        public void PeekShouldReturnElementAtPointer();
    }
}
