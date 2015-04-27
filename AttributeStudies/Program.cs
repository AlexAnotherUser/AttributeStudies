
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributeStudies.Models;


namespace AttributeStudies
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            MessagePrint("Hey from old function!");

            MessagePrint_New("Hey from new message print!");

        }

        [Conditional("TEST1")]
        //[Obsolete("This is obsolete function!",true)]
        private static void MessagePrint(string message)
        {
            Console.WriteLine(message);
        }

        [DeBugInfo(1,"alexbeyd","first review")]
        [Simple("Test")]
        private static void MessagePrint_New(string message)
        {
            Console.WriteLine(message);
        }
    }
}
