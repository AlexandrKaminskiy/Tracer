using System;
using TracerLibrary;
using System.Diagnostics;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Console.WriteLine(DateTimeOffset.Now.ToUnixTimeMilliseconds());

            meth();
            //Class1 class1 = new Class1();
        }
        static void meth()
        {
            StackTrace stackTrace = new StackTrace();
            Console.WriteLine(stackTrace.GetFrame(1).GetMethod().Name);
            Console.WriteLine(stackTrace.GetFrame(1).GetMethod().DeclaringType.Name);
        }
    }
}