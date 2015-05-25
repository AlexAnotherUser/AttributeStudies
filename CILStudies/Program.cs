using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeStudies.Models;

namespace CILStudies
{
    class Program
    {
        private static void Main(string[] args)
        {
            PrintConsole("Hello CIL! Please type ENTER");
            Console.ReadLine();


        }

        [MustTest]
        private static void PrintConsole(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
