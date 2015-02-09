using System;
using System.Configuration;
using CodeReviewLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codereview.Tests
{
    [TestClass]
    public class When_Code_Review_Is_Used
    {
        private readonly TestHelper _helper = new TestHelper();

        [TestMethod]
        public void it_should_throw_exception_when_in_active_state()
        {
       
        _helper. ThrowsAnException<Exception>(() => CodeReview.FromThisLine());
         const string message = "Need to review code";
         var exceptionThrown = _helper.ThrowsAnException<Exception>(() => CodeReview.FromThisLine(message));
         Assert.AreEqual(message, exceptionThrown.Message);

         _helper.ThrowsAnException<Exception>(() => CodeReview.ThisMethod());
         exceptionThrown = _helper.ThrowsAnException<Exception>(() => CodeReview.ThisMethod(message));
         Assert.AreEqual(message, exceptionThrown.Message);

        }
    }
}
