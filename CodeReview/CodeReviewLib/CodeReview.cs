using System;
using System.Diagnostics;

namespace CodeReviewLib
{
    public class CodeReview : ACodeReview
    {
        protected static bool RemovalNotification { set; get; }

        protected static bool CanRun()
        {
            if (!RemovalNotification)
            {
                //   Console.WriteLine("There are one or more codereview lines existing in application. Try to remove all of them");
                RemovalNotification = true;
            }

#if (DEBUG)
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["CodeReview"].ToLower() == "true";
            }
            catch (Exception e)
            {
                //  Console.WriteLine("Configuration Error: Try adding <add key=\"CodeReview\" value=\"false\"/>  to appSettings section of your config file" + e.Message);
            }

#endif


            return true;
        }

        /// <summary>
        /// This will always throw an exception except if you are in debug mode AND your  appSettings section of your config file has  key="CodeReview" and value="false" 
        /// </summary>
        /// <param name="codeReviewMessage">The message that will be in the exception thrown along with specific method where code review is required</param>
        public static void ThisMethod(string codeReviewMessage = null)
        {
            if (!CanRun()) return;
            var callStack = new StackFrame(1, true);

            // get call stack
            var stackTrace = new StackTrace();

            var callingMethod =
                stackTrace.GetFrame(1).GetMethod();

            var callingType = callingMethod.ReflectedType;

            var trace = "TODO : Code Review Required In The Method:  " + callingType + " . " + callingMethod + "  " +
                        callStack.GetFileName() + "  Check File Line: " + callStack.GetFileLineNumber();


            if (codeReviewMessage != null)
            {
                // Console.WriteLine(codeReviewMessage);
            }
            else
            {
                codeReviewMessage = trace;
            }

            // Console.WriteLine(trace);
            throw new Exception(codeReviewMessage, new Exception(trace));
        }

        /// <summary>
        /// This will always throw an exception except if you are in debug mode AND your  appSettings section of your config file has  key="CodeReview" and value="false" 
        /// </summary>
        /// <param name="codeReviewMessage">The message that will be in the exception thrown along with specific location where code review is required</param>
        public static void FromThisLine(string codeReviewMessage = null)
        {
            if (!CanRun()) return;
            var callStack = new StackFrame(1, true);
            var trace = "TODO : Code Review Required In File: " + callStack.GetFileName() + " starting from Line: " +
                        callStack.GetFileLineNumber();
            if (codeReviewMessage != null)
            {
                // Console.WriteLine(codeReviewMessage);
            }
            else
            {
                codeReviewMessage = trace;
            }

            //  Console.WriteLine(trace);
            throw new Exception(codeReviewMessage, new Exception(trace));
        }
    }
}