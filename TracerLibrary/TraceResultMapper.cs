using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    internal class TraceResultMapper
    {
        long time;
        internal List<Threads> ToTraceResultDto(TraceResult traceResult)
        {
            List<Threads> traceResultDtos = new List<Threads>();
            var enumerator = traceResult.resultDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Threads traceResultDto = new Threads();
                time = 0;
                int ti = enumerator.Current.Key;
                RunResultNode runResultNode = enumerator.Current.Value.invokedMethods;
                Method methodDto = ToMethodDto(runResultNode);
                traceResultDto.methods = ToMethodDto(runResultNode);
                traceResultDto.id = ti;
                traceResultDto.time = time;
                traceResultDtos.Add(traceResultDto);
            }
            return traceResultDtos;
        }
        Method ToMethodDto(RunResultNode runResultNode)
        {
            List<Method> childMethodDtos = new List<Method>();
            foreach (var method in runResultNode.ChildMethods)
            {
                childMethodDtos.Add(ToMethodDto(method));
            }
            Method methodDto = ToMethodDto(runResultNode.ThisMethod);
            methodDto.methods = childMethodDtos;
            return methodDto;
        }

        Method ToMethodDto(RunResult runResult)
        {
            Method methodDto = new Method();
            methodDto.Name = runResult.MethodName;
            methodDto.Time = runResult.ElapsedTime;
            methodDto.Class = runResult.ClassName;
            time += runResult.ElapsedTime;
            return methodDto;
        }
    }
}
