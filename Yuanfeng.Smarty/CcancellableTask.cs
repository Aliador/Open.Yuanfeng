using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Yuanfeng.Smarty
{
    public class CancellableTask
    {
        public delegate object WorkCallback(object arg);
        public delegate void CancelCallback(object state);
        protected class TimeoutState
        {
            internal Thread thread;
            internal object state;
            public TimeoutState(Thread thread, object state)
            {
                this.thread = thread;
                this.state = state;
            }
        }
        protected WorkCallback workCallback;
        protected CancelCallback cancelCallback;
        protected WorkCallback wrapper;
        public CancellableTask(WorkCallback workCallback)
        {
            this.workCallback = workCallback;
        }
        public CancellableTask(WorkCallback workCallback, CancelCallback cancelCallback)
        {
            this.workCallback = workCallback;
            this.cancelCallback = cancelCallback;
        }

        public IAsyncResult BeginInvoke(object arg, AsyncCallback asyncCallback, object state, int timeout)
        {
            wrapper = delegate (object argv)
            {
                AutoResetEvent e = new AutoResetEvent(false);
                try
                {
                    TimeoutState waitOrTimeoutState = new TimeoutState(Thread.CurrentThread, state);
                    ThreadPool.RegisterWaitForSingleObject(e, WaitOrTimeout, waitOrTimeoutState, timeout, true);
                    return workCallback(argv);
                }
                finally
                {
                    e.Set();
                }
            };
            IAsyncResult asyncResult = wrapper.BeginInvoke(arg, asyncCallback, state);
            return asyncResult;
        }
        public object EndInvoke(IAsyncResult result)
        {
            return wrapper.EndInvoke(result);
        }
        protected void WaitOrTimeout(object state, bool isTimeout)
        {
            try
            {
                if (isTimeout)
                {
                    TimeoutState waitOrTimeoutState = state as TimeoutState;
                    if (null != cancelCallback)
                    {
                        cancelCallback(waitOrTimeoutState.state);
                    }
                    else
                    {
                        waitOrTimeoutState.thread.Abort();
                    }
                }
            }
            catch { }
        }

    }
}
