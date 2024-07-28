using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleQueueTests : ICircleContainerTests
    {
        public ICircleQueueMocks Mocks { get; set; }

        public void EnqueueToEmptyShouldAdd();
        public void EnqueueToPartiallyFilledShouldAdd();
        public void EnqueueToFullShouldReplace();
        public void DequeueShouldRemoveFirstIn();
        public void RotateShouldIncrementPointerPosition();
    }
}
