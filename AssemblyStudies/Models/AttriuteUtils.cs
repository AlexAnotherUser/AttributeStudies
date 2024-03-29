﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyStudies.Models
{
    //TODO: implement method that gets a function and returns it's custom attributes


    public class AttributeUtils
    {
        public List<string> GetMethodsWithAttr(List<string> attributesList, IEnumerable<Assembly> attributesAssemblies, IEnumerable<Assembly> targetAssemblies)
        {
            var methodsList = new List<string>();

            IEnumerable<Assembly> assemblies = attributesAssemblies as IList<Assembly> ?? attributesAssemblies.ToList();
            foreach (var assmType in (from ta in targetAssemblies from t in ta.GetTypes() select t))
            {
                var methods = new List<MethodInfo>(assmType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public));

                //all methods
                foreach (MethodInfo method in methods)
                {
                    //all attributes by name
                    foreach (var attrName in attributesList)
                    {
                        Type attrType = (from aa in assemblies from t in aa.GetTypes() where t.Name == attrName select t).FirstOrDefault();

                        if (attrType != null)
                        {
                            var customeAttribute = Attribute.GetCustomAttribute(method, attrType, false);

                            if (customeAttribute == null) continue;

                            methodsList.Add(method.Name);
                        }
                    }
                }
            }

            return methodsList;
        }

        public MethodInfo GetMethodInfoNameWithSpecificAttribute(string methodName, string attributeName, IEnumerable<Assembly> attributesAssemblies, IEnumerable<Assembly> targetAssemblies)
        {
            MethodInfo result = null;

            IEnumerable<Assembly> assemblies = attributesAssemblies as IList<Assembly> ?? attributesAssemblies.ToList();
            foreach (var assmType in (from ta in targetAssemblies from t in ta.GetTypes() select t))
            {
                var methods = new List<MethodInfo>(assmType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public));

                //TODO: if it's possible that we will get 2 methods from different hierarchies?
                result = (from m in methods where m.Name.Equals(methodName) select m).FirstOrDefault();

                Type attrType = (from aa in assemblies from t in aa.GetTypes() where t.Name == attributeName select t).FirstOrDefault();

                if (attrType != null && result != null)
                {
                    var customeAttribute = Attribute.GetCustomAttribute(result, attrType, false);

                    if (customeAttribute != null) break;
                }
            }

            return result;
        }

        public object GetAttributeForSpecificMethodName(string attributeName, string methodName, IEnumerable<Assembly> attributesAssemblies, IEnumerable<Assembly> targetAssemblies)
        {
            IEnumerable<Assembly> assemblies = attributesAssemblies as IList<Assembly> ?? attributesAssemblies.ToList();
            foreach (var assmType in (from ta in targetAssemblies from t in ta.GetTypes() select t))
            {
                var methods = new List<MethodInfo>(assmType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public));

                //TODO: if it's possible that we will get 2 methods from different hierarchies?
                var method = (from m in methods where m.Name.Equals(methodName) select m).FirstOrDefault();

                Type attrType = (from aa in assemblies from t in aa.GetTypes() where t.Name == attributeName select t).FirstOrDefault();

                if (attrType != null && method != null)
                {
                    Attribute result = Attribute.GetCustomAttribute(method, attrType, false);

                    if (result != null) return result;
                }
            }

            return null;
        }
    }
}
