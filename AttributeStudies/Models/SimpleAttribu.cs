using System;

namespace AttributeStudies.Models
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SimpleAttribute : Attribute
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public SimpleAttribute(string name)
        {
            _name = name;
        }

    }
}
