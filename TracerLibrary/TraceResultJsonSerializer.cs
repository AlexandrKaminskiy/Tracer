using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace TracerLibrary
{
    namespace Serialization
    {
        internal class TraceResultJsonSerializer : Serialization
        {
            public void Serialize(List<Threads> traceResult)
            {

                Threads[] traceResultDtos = traceResult.ToArray();
                
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream("traceResult.json", FileMode.OpenOrCreate))
                {
                    JsonSerializer.SerializeAsync<List<Threads>>(fs, traceResult);

                    Console.WriteLine("Object has been serialized");
                }
            }

        }
    }
    
}
