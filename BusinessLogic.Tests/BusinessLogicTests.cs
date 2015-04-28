using System;
using System.Linq;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        public void GetMethodName()
        {
            Assert.AreEqual((new MethodsUnderTest()).Method_2(), "Method_2");
        }

        [TestMethod]
        public void MethodHaveAttributes()
        {
            var result = MethodsUnderTest.Method_1();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}
