using System;
using Collections.Generic.CircularTests.Mocks.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleContainerTests
    {
        public object TestSetup(object mock);

        public void SizeShouldEqualConstructorInputDataLength();
        public void SizeShouldEqualDataLength();
        public void CountShouldStartAtZero();
        public void CountShouldStartAtConstructorInputCount();
        public void PeekShouldReturnElementAtPointer();
        public void ContainsShouldReturnTrueIfElementIsPresent();
        public void ContainsShouldReturnFalseIfElementIsNotPresent();
        public void DataArrayShouldBeTraversibleInOrder();
        public void DataArrayShouldBeAccessibleViaIndexer();
    }
}
