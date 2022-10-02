using System;
using TracerLibrary;
using System.Diagnostics;
using ActivityWorkers;
using System.Collections.Concurrent;
using System.Threading;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new ITracerImpl();
            Sorting sorting = new Sorting(tracer);
            Filtering filtering = new Filtering(tracer);

            Thread t = new Thread(new ThreadStart(() => filtering.Filter(new int[] {1, -3, 5, -7})));
            t.Start();
            sorting.SortAndFilter(new int[] { -2, 8, 6, 3, 5 });
            t.Join();
            TraceResult traceResult = tracer.GetTraceResult();
            Console.WriteLine("123");
        }
    }
}