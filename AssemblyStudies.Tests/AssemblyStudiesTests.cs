using System;
using System.Collections.Generic;
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
            var attrUtils = new AttriuteUtils();

            List<string> methods = attrUtils.GetMethodsWithAttr(
                new List<string> { "MustTest", "SimpleAttribute" },
                (new List<Assembly> { typeof(MustTest).Assembly, typeof(SimpleAttribute).Assembly }).Distinct(),
                new List<Assembly> { typeof(MockMethods).Assembly });

            Assert.IsNotNull(methods);
            Assert.IsTrue((methods.ToArray())[0] == "MockMethod_1");
        }
    }
}
