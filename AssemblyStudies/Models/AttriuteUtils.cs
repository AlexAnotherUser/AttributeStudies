using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyStudies.Models
{
    public class AttriuteUtils
    {
        public List<string> GetMethodsWithAttr(List<string> attributesList, IEnumerable<Assembly> attributesAssemblies, IEnumerable<Assembly> targetAssemblies)
        {
            var methodsList = new List<string>();

            foreach (var assmType in (from ta in targetAssemblies from t in ta.GetTypes() select t))
            {
                var methods = new List<MethodInfo>(assmType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public));

                //all methods
                foreach (MethodInfo method in methods)
                {
                    //all attributes by name
                    foreach (var attrName in attributesList)
                    {
                        Type attrType = (from aa in attributesAssemblies from t in aa.GetTypes() where t.Name == attrName select t).FirstOrDefault();

                        if (attrType != null)
                        {
                            var customeAttribute = Attribute.GetCustomAttribute(method, attrType, false);

                            if (customeAttribute == null) continue;
                            //Console.WriteLine(attrType.Name + "." + method.Name);
                            //Console.WriteLine("The method has custom attribute " + attrType.Name);

                            methodsList.Add(method.Name);
                        }
                    }
                }
            }

            return methodsList;
        }

        //TODO: implement method that gets a function and returns it's custom attributes

    }
}
