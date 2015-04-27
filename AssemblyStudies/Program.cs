using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AssemblyStudies.Models;
using AttributeStudies;
using AttributeStudies.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AssemblyStudies
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodsUnderTest.Method_1();
        }

        private static void PrintAttrsList()
        {
            // string assName = "AttributeStudies.Tests.Tests";
            Assembly a = typeof(AttributeStudies.Tests.Tests).Assembly;

            Console.WriteLine("Methods of Tests: ");

            foreach (var type in a.GetTypes())
            {
                MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

                PrintCurtomAttr<SimpleAttribute>(methods);
            } 
        }

        private static void PrintCurtomAttr<T>(IEnumerable<MethodInfo> methods)
        {
            foreach (MethodInfo method in methods)
            {
                var attr =
                    Attribute.GetCustomAttribute(method, typeof(T), false) as SimpleAttribute;

                if (attr != null)
                {
                    Console.WriteLine(typeof(T).Name + "." + method.Name);
                    Console.WriteLine("The method has custom attribute " + typeof(T).Name);
                }
            }
        }
    }
}
