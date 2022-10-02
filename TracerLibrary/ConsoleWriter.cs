using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    public class ConsoleWriter : Writer
    {
        private ITracer tracer;
        public ConsoleWriter(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public void WriteResults()
        {
            TraceResultMapper traceResultMapper = new TraceResultMapper();
            var trDto = traceResultMapper.ToTraceResultDto(tracer.GetTraceResult());

            trDto.ForEach(result => {
                string res = "id : " + result.id + "\n" +
                "time : " + result.time + "\n" +
                "methods : " + "\n";

                res += GetMethInfoAsString(result.methods, 1);

                Console.WriteLine(res);
            });
        }

        string GetMethInfoAsString(Method methods, int tabCount)
        {
            
            string methInfo = Tabs(tabCount) + "Name : " + methods.Name + "\n" +
                Tabs(tabCount) + "Class : " + methods.Class + "\n" +
                Tabs(tabCount) + "Time : " + methods.Time + "\n\n";
            foreach (var method in methods.methods)
            {
                methInfo += GetMethInfoAsString(method, tabCount + 1);
            }
            return methInfo;
        }

        string Tabs(int tabCount)
        {
            string tabs = "";
            for (int i = 0; i < tabCount; i++)
            {
                tabs += "\t";
            }
            return tabs;
        }
    }
}
