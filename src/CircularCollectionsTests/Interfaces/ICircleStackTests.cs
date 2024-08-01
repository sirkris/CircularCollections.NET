using Collections.Generic.CircularTests.Mocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Generic.CircularTests.Interfaces
{
    public interface ICircleStackTests : ICircleContainerTests
    {
        public object TestSetup(object mock, bool indexerIsReadOnly = true);

        public ICircleQueueAndStackMocks Mocks { get; set; }

        public void PushShouldAddInitialElement();
        public void PushToPartiallyFilledShouldAdd();
        public void PushToFullShouldReplace();
        public void PopShouldRemoveLastIn();
        public void RotateShouldDecrementPointerPosition();
        public void DataArrayShouldBeWritableViaIndexerIfNotReadOnly();
    }
}
