using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleHeapTests : ICircleContainerTests
    {
        public object TestSetup(object mock);

        public ICircleHeapMocks Mocks { get; set; }

        public void PushShouldAddInitialElement();
        public void PointerShouldStartAtTop();
        public void TopShouldPointToElementAtIndexZero();
        public void CountShouldIncrementWhenPushAdds();
        public void CountShouldNotIncrementWhenPushDoesNotAdd();
        public void PopShouldDecrementCount();
        public void RotateShouldIncrementPointerPosition();
        public void ResetShouldSetPointerToZero();
        public void ContainsShouldReturnTrueIfIndexedElementIsPresent();
        public void ContainsShouldReturnFalseIfIndexedElementIsNotPresent();
        public void ContainsShouldReturnTrueIfCombinedIndexedElementIsPresent();
        public void ContainsShouldReturnFalseIfCombinedIndexedElementIsNotPresent();
    }
}
