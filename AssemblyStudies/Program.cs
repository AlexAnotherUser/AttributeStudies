using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AssemblyStudies.Models;
using AttributeStudies;
using AttributeStudies.Models;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AssemblyStudies
{
    class Program
    {
        static void Main(string[] args)
        {
            var attrUtils = new AttriuteUtils();

            List<string> methods = attrUtils.GetMethodsWithAttr(
                new List<string> { "MustTest", "SimpleAttribute" },
                (new List<Assembly> { typeof(MustTest).Assembly, typeof(SimpleAttribute).Assembly }).Distinct(),
                new List<Assembly> { typeof(MethodsUnderTest).Assembly });

            methods.ForEach(Console.WriteLine);
        }
    }
}
