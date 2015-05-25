﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeStudies.Models
{
    public class MustTest : Attribute
    {
        public string Name { get; set; }

        public MustTest()
        {
            Name = "Any";
        }

        public MustTest(string name)
        {
            Name = name;
        }

        public void GetMyStack()
        {
            StackFrame[] sf = (new StackTrace()).GetFrames();
        }

    }
}
