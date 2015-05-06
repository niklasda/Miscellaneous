using System;

namespace Dotway.Demo
{
    public class AsyncResult<TResult> : AsyncResultNoResult
    {
        private TResult result = default(TResult);

        public AsyncResult(AsyncCallback asyncCallback, Object state) : base(asyncCallback, state) { }

        public void SetAsCompleted(TResult result, Boolean completedSynchronously)
        {
            this.result = result;

            SetAsCompleted(null, completedSynchronously);
        }

        new public TResult EndInvoke()
        {
            base.EndInvoke();
            return result;
        }
    }
}