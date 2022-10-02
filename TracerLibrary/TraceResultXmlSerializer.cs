using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TracerLibrary
{
    namespace Serialization
    {
        public class TraceResultXmlSerializer : Serialization, Writer
        {
            private ITracer tracer;
            public TraceResultXmlSerializer(ITracer tracer)
            {
                this.tracer = tracer;
            }
            public void Serialize(List<Threads> traceResult)
            {
                Threads[] traceResultDtos = traceResult.ToArray();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Threads>));

                using (FileStream fs = new FileStream("traceResult.xml", FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, traceResult);

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
