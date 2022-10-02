using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace TracerLibrary
{
    namespace Serialization
    {
        public class TraceResultJsonSerializer : Serialization, Writer
        {
            private ITracer tracer;
            public TraceResultJsonSerializer(ITracer tracer)
            {
                this.tracer = tracer;
            }
            public void Serialize(List<Threads> traceResult)
            {

                Threads[] traceResultDtos = traceResult.ToArray();
                
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream("traceResult.json", FileMode.Create))
                {
                    JsonSerializer.SerializeAsync<List<Threads>>(fs, traceResult, new JsonSerializerOptions()
                    {
                        WriteIndented = true
                    });

                    Console.WriteLine("Object has been serialized");
                }
            }

            public void WriteResults()
            {
                TraceResultMapper traceResultMapper = new TraceResultMapper();
                var trDto = traceResultMapper.ToTraceResultDto(tracer.GetTraceResult());
                Serialize(trDto);
            }
        }
    }
    
}
