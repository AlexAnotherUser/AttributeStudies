﻿using System;
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
    public class  UTest
    {
        [TestMethod]
        public void FindMethodsWithAttrs()
        {
            List<string> methods = (new AttributeUtils()).GetMethodsWithAttr(
                 new List<string> { "MustTest" },
                 (new List<Assembly> { typeof(MustTest).Assembly }).Distinct(),
                 new List<Assembly> { typeof(MockMethods).Assembly });

            Assert.IsNotNull(methods);
            Assert.IsTrue(methods.Count > 0);
            Assert.IsTrue((methods.ToArray())[0] == "MockMethod_1");

        }

        [TestMethod]
        public void FindTestMethods()
        {
            List<string> methods = (new AttributeUtils()).GetMethodsWithAttr(
                new List<string> { "TestMethodAttribute" },
                (new List<Assembly> { typeof(TestMethodAttribute).Assembly }).Distinct(),
                new List<Assembly> { typeof(MockUnitTests).Assembly });

            Assert.IsNotNull(methods);
            Assert.IsTrue(methods.Count > 0);
            Assert.IsTrue(methods.Contains("Test1"));
        }

        [TestMethod]
        public void GetSpecificMethodWithSpecificAttribute()
        {
            string methodToCheck = "MockMethod_1";

            var method = (new AttributeUtils()).GetMethodInfoNameWithSpecificAttribute(
                methodToCheck,
                "MustTest",
                (new List<Assembly> { typeof(MustTest).Assembly }).Distinct(),
                 new List<Assembly> { typeof(MockMethods).Assembly });

            Assert.IsNotNull(method);
            Assert.AreEqual(method.Name, methodToCheck);
        }

        [TestMethod]
        public void GetSpecificAttributeForSpecificMethod()
        {
            string methodToCheck = "MockMethod_1";
            string attrToCheck = "MustTest";

            var attr = (new AttributeUtils()).GetAttributeForSpecificMethodName(
                attrToCheck,
                methodToCheck,
                (new List<Assembly> { typeof(MustTest).Assembly }).Distinct(),
                 new List<Assembly> { typeof(MockMethods).Assembly });

            Assert.IsNotNull(attr);
            attr.GetType().GetMethod("GetMyStack").Invoke(Activator.CreateInstance(typeof (MustTest)), null);
            Assert.AreEqual(attr.GetType().Name, attrToCheck);
        }

        [TestMethod]
        public void SpecificMethodWithoutSpecificAttribute()
        {
            string methodToCheck = "MockMethod_NoAttributes";

            var method = (new AttributeUtils()).GetMethodInfoNameWithSpecificAttribute(
                methodToCheck,
                "MustTest",
                (new List<Assembly> { typeof(MustTest).Assembly }).Distinct(),
                 new List<Assembly> { typeof(MockMethods).Assembly });

            Assert.IsNull(method);
        }

        [TestMethod]
        public void FindMethodsNotTested()
        {

        }

        [TestMethod]
        public void GetCalledMethods()
        {
            StackFrame[] sf = (new StackTrace()).GetFrames();
        }
    }
}
