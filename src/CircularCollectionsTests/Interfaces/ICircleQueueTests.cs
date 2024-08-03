using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleQueueTests : ICircleContainerTests
    {
        public object TestSetup(object mock, bool indexerIsReadOnly = true);

        public ICircleQueueAndStackMocks Mocks { get; set; }

        public void EnqueueShouldAddInitialElement();
        public void EnqueueToPartiallyFilledShouldAdd();
        public void EnqueueToFullShouldReplace();
        public void DequeueShouldRemoveFirstIn();
        public void RotateShouldIncrementPointerPosition();
        public void DataArrayShouldBeWritableViaIndexerIfNotReadOnly();
    }
}
