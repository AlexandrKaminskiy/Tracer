using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TracerLibrary
{
    namespace Serialization
    {
        internal class TraceResultXmlSerializer : Serialization
        {
            public void Serialize(List<Threads> traceResult)
            {
                Threads[] traceResultDtos = traceResult.ToArray();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Threads>));

                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream("traceResult.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, traceResult);

                    Console.WriteLine("Object has been serialized");
                }
            }
        }
    }
   
}
