using AttributeStudies.Models;

namespace BusinessLogic.Models
{
    public class MethodsUnderTest
    {
        [MustTest]
        public static void Method_1()
        {
            //var ma = MethodInfo.GetCurrentMethod().GetCustomAttributes();
        }

        [Simple("Simple")]
        private void Method_2() { }

        [Simple("Simple")]
        protected void Method_3() { }

        [Simple("Simple")]
        private static void Method_4() { }

        [Simple("Simple")]
        protected static void Method_5() { }

        [SimpleAttribute("Simple")]
        public static void Method_6() { }
    }
}
