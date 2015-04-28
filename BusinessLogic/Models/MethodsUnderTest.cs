using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AttributeStudies.Models;

namespace BusinessLogic.Models
{
    public class MethodsUnderTest
    {
        [MustTest]
        public static IEnumerable<Attribute> Method_1()
        {
            return MethodBase.GetCurrentMethod().GetCustomAttributes();
        }

        [MustTest]
        public string Method_2()
        {
            return MethodBase.GetCurrentMethod().Name;
        }

        [MustTest]
        protected void Method_3() { }

        [MustTest]
        public static void Method_4() { }

        [MustTest]
        protected static void Method_5() { }

        [MustTest]
        public static void Method_6() { }
    }
}
