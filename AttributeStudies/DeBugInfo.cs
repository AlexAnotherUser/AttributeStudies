using System;

namespace AttributeStudies
{
    //a custom attribute BugFix to be assigned to a class and its members
    [AttributeUsage(AttributeTargets.Class |
    AttributeTargets.Constructor |
    AttributeTargets.Field |
    AttributeTargets.Method |
    AttributeTargets.Property,
    AllowMultiple = true)]
    class DeBugInfo : Attribute
    {
        private string devName;
        private int bugNumber;
        private string lastReview;
        private string message;

        public int BugNumber
        {
            get { return bugNumber; }
        }

        public string DevName
        {
            get { return devName; }
        }

        public string LastReview
        {
            get { return lastReview; }
        }

        public string Message { get; set; }

        public DeBugInfo(int bgnum, string devname, string lastrev)
        {
            bugNumber = bgnum;
            devName = devname;
            lastReview = lastrev;
        }
    }
}
