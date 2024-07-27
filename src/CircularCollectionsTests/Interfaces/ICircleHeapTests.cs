using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleHeapTests : ICircleContainerTests
    {
        public void PushShouldAddInitialElement();
        public void PointerShouldStartAtTop();
        public void TopShouldPointToElementAtIndexZero();
        public void CountShouldIncrementWhenPushAdds();
        public void CountShouldNotIncrementWhenPushDoesNotAdd();
        public void PopShouldDecrementCount();
        public void RotateShouldIncrementPointerPosition();
        public void ResetShouldSetPointerToZero();
        public void ContainsShouldReturnTrueIfElementIsPresent();
        public void ContainsShouldReturnFalseIfElementIsNotPresent();
        public void ContainsShouldReturnTrueIfIndexedElementIsPresent();
        public void ContainsShouldReturnFalseIfIndexedElementIsNotPresent();
        public void ContainsShouldReturnTrueIfCombinedIndexedElementIsPresent();
        public void ContainsShouldReturnFalseIfCombinedIndexedElementIsNotPresent();
        public void DataArrayShouldBeTraversibleInOrder();
        public void DataArrayShouldBeAccessibleViaIndexer();
    }
}
