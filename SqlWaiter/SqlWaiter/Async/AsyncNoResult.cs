using System;
using System.Threading;

namespace Dotway.Demo
{
    public class AsyncResultNoResult : IAsyncResult
    {
        private readonly AsyncCallback asyncCallback;
        private readonly Object asyncState;

        private const Int32 statePending = 0;
        private const Int32 stateCompletedSynchronously = 1;
        private const Int32 stateCompletedAsynchronously = 2;
        private Int32 completedState = statePending;

        private ManualResetEvent asyncWaitHandle;

        private Exception exception;

        public AsyncResultNoResult(AsyncCallback asyncCallback, Object state)
        {
            this.asyncCallback = asyncCallback;
            asyncState = state;
        }

        public void SetAsCompleted(Exception exception, Boolean completedSynchronously)
        {
            this.exception = exception;

            Int32 prevState = Interlocked.Exchange(ref completedState, completedSynchronously ? stateCompletedSynchronously : stateCompletedAsynchronously);
            if (prevState != statePending)
                throw new InvalidOperationException("You can set a result only once");

            if (asyncWaitHandle != null)
                asyncWaitHandle.Set();

            if (asyncCallback != null)
                asyncCallback(this);
        }

        public void EndInvoke()
        {
            if (!IsCompleted)
            {
                AsyncWaitHandle.WaitOne();
                AsyncWaitHandle.Close();
                asyncWaitHandle = null;
            }

            if (exception != null)
                throw exception;
        }

        #region Implementation of IAsyncResult

        public Object AsyncState
        {
            get
            {
                return asyncState;
            }
        }

        public Boolean CompletedSynchronously
        {
            get
            {
                return completedState == stateCompletedSynchronously;
            }
        }

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (asyncWaitHandle == null)
                {
                    Boolean done = IsCompleted;
                    ManualResetEvent manualResetEvent = new ManualResetEvent(done);
                    if (Interlocked.CompareExchange(ref asyncWaitHandle, manualResetEvent, null) != null)
                    {
                        manualResetEvent.Close();
                    }
                    else if (!done && IsCompleted)
                    {
                        asyncWaitHandle.Set();
                    }
                }
                return asyncWaitHandle;
            }
        }

        public Boolean IsCompleted
        {
            get
            {
                return completedState != statePending;
            }
        }

        #endregion
    }
}