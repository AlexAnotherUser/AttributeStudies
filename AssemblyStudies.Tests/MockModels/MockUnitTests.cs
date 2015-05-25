using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyStudies.Tests.MockModels
{
    [TestClass]
    public class MockUnitTests
    {
        [TestMethod]
        public void Test1() 
        {
            (new MockMethods()).MockMethod_1();
        }
    }
}
