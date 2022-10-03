using System;
using TracerLibrary;
using System.Diagnostics;
using ActivityWorkers;
using System.Collections.Concurrent;
using System.Threading;
using TracerLibrary.Serialization;
using System.Collections.Generic;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ITracer tracer = new TracerLibrary.Tracer();

            Sorting sorting = new Sorting(tracer);
            Filtering filtering = new Filtering(tracer);

            Thread t = new Thread(new ThreadStart(() => filtering.Filter(new int[] {1, -3, 5, -7})));
            t.Start();
            sorting.SortAndFilter(new int[] { -2, 8, 6, 3, 5 });
            t.Join();
            Writer writer = new ConsoleWriter(tracer);
            Writer xmlWriter = new TraceResultXmlSerializer(tracer);
            Writer jsonWriter = new TraceResultJsonSerializer(tracer);
            writer.WriteResults();
            xmlWriter.WriteResults();
            jsonWriter.WriteResults();
        }
        
    }
}