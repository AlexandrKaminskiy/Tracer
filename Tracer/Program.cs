using System;
using TracerLibrary;
using System.Diagnostics;
using ActivityWorkers;
using System.Collections.Concurrent;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new ITracerImpl();
            Sorting sorting = new Sorting(tracer);
            sorting.SortAndFilter(new int[] { -2, 8, 6, 3, 5 });
           
        }
    }
}