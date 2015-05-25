using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeStudies.Models;

namespace AssemblyStudies.Tests.MockModels
{
    public class MockMethods
    {
        [MustTest]
        public void MockMethod_1()
        {
          //this is mock method used to test it's custom attribute  
        }

        [MustTest]
        public void MockMethod_2()
        {
            //this is mock method
        }

        public void MockMethod_NoAttributes()
        {
            
        }
    }
}
