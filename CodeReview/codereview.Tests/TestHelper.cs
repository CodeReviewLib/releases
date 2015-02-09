using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codereview.Tests
{
    public class TestHelper
    {
        private Exception ThrowsAnException(Action action)
        {
            return ThrowsAnException<Exception>(action);
        }

        public Exception ThrowsAnException<T>(Action action) where T : Exception
        {
            return ThrowsAnException(action, typeof(T));
        }

        private Exception ThrowsAnException(Action action, Type t)
        {
            if (action == null) throw new NotImplementedException("No action specified for method 'ThrowsAnException'");
            Exception exception = null;
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {


                if (t == null)
                {
                    exception = e;
                }
                else
                {
                    if (t.Name == e.GetType().Name)
                    {
                        exception = e;
                    }
                }

            }
            var exceptionType = t == null ? "'Exception'" : "'" + t.Name + "'";
            Assert.AreNotEqual(null, exception, "Action was expected to throw " + exceptionType + ", but it failed to do so");
            return exception;
        }


    }
}