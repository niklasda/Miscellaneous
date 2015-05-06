using System;
using System.Threading;
using System.Xml;

namespace Dotway.Demo
{
    public class DbWaiter
    {
        public static IAsyncResult BeginLoad(AsyncCallback callback, Object state)
        {
            AsyncResultState<Form1, XmlDocument> asyncResult = new AsyncResultState<Form1, XmlDocument>(callback, state);

            if (!asyncResult.IsCompleted)
                ThreadPool.QueueUserWorkItem(LoadHelper, asyncResult);

            return asyncResult;
        }

        public static XmlDocument EndLoad(IAsyncResult asyncResult)
        {
            AsyncResult<XmlDocument> ar = (AsyncResult<XmlDocument>)asyncResult;
            return ar.EndInvoke();
        }

        private static void LoadHelper(object state)
        {
            AsyncResultState<Form1, XmlDocument> asyncResult = (AsyncResultState<Form1, XmlDocument>)state;
            Form1 sqlString = asyncResult.AsyncState;
            try
            {
                asyncResult.SetAsCompleted(sql.Receive(), false);
            }
            catch (Exception e)
            {
                asyncResult.SetAsCompleted(e, false);
            }
        }
    }
}