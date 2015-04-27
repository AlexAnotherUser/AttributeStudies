using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;
using AttributeStudies.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttributeStudies.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [Simple("My Simple")]
        public void Test1()
        {
            var ma = MethodInfo.GetCurrentMethod().GetCustomAttributes();
            //Console.WriteLine("Attrs:" + ma.ElementAt(0).;
            Assert.AreEqual(ma.Count(), 2);
        }

        
    }
}
