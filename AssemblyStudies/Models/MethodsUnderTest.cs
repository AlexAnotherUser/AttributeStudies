using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AttributeStudies.Models;

namespace AssemblyStudies.Models
{
    public static class MethodsUnderTest
    {
        [MustTest]
        public static void Method_1()
        {
            var ma = MethodInfo.GetCurrentMethod().GetCustomAttributes();

        }
    }
}
