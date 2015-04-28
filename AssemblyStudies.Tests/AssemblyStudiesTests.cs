using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AssemblyStudies.Models;
using AssemblyStudies.Tests.MockModels;
using AttributeStudies.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AssemblyStudies.Tests
{
    [TestClass]
    public class UTest
    {
        [TestMethod]
        public void FindMethodsWithAttrs()
        {
            List<string> methods = (new AttriuteUtils()).GetMethodsWithAttr(
                 new List<string> { "MustTest", "SimpleAttribute" },
                 (new List<Assembly> { typeof(MustTest).Assembly, typeof(SimpleAttribute).Assembly }).Distinct(),
                 new List<Assembly> { typeof(MockMethods).Assembly });

            Assert.IsNotNull(methods);
            Assert.IsTrue(methods.Count > 0);
            Assert.IsTrue((methods.ToArray())[0] == "MockMethod_1");
        }

        [TestMethod]
        public void FindTestMethods()
        {
            List<string> methods = (new AttriuteUtils()).GetMethodsWithAttr(
                new List<string> { "TestMethodAttribute" },
                (new List<Assembly> { typeof(TestMethodAttribute).Assembly }).Distinct(),
                new List<Assembly> { typeof(MockTests).Assembly });

            Assert.IsNotNull(methods);
            Assert.IsTrue(methods.Count > 0);
            Assert.IsTrue(methods.Contains("Test1"));
        }

        [TestMethod]
        public void GetCalledMethods()
        {
            StackFrame[] sf = (new StackTrace()).GetFrames();

        }
    }
}
