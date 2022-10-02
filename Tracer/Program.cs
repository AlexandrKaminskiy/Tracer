using System;
using TracerLibrary;
using System.Diagnostics;
using ActivityWorkers;
using System.Collections.Concurrent;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

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
            tracer.GetTraceResult();
            Console.WriteLine("123");
            test();
        }
        static void test()
        {
            string s = "12312j3";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TraceResult));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                //xmlSerializer.Serialize(fs, result);

                Console.WriteLine("Object has been serialized");
            }
        }
    }
}