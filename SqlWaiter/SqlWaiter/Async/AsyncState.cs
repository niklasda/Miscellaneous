using System;

namespace Dotway.Demo
{
    public class AsyncResultState<TState, TResult> : AsyncResult<TResult>
    {
        private TState state;

        public AsyncResultState(AsyncCallback asyncCallback, object state)
            : base(asyncCallback, state)
        {
            SetState(state);
        }

        public void SetState(object state)
        {
            if (state == null)
            {
                SetAsCompleted(new ArgumentNullException("state"), true);
                return;
            }

            Type genericType = typeof(TState);
            Type stateType = state.GetType();
            if (!genericType.Equals(stateType) &&
                stateType.GetInterface(genericType.Name) == null)
            {
                SetAsCompleted(new ArgumentException(string.Format("Expected state to be of type {0}! It is in of type {1}!", genericType, stateType)), true);
            }

            this.state = (TState)state;
        }

        public new TState AsyncState { get { return state; } }
    }
}
