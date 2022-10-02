using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    internal class TraceResultMapper
    {
        long time;
        internal List<TraceResultDto> ToTraceResultDto(TraceResult traceResult)
        {
            List<TraceResultDto> traceResultDtos = new List<TraceResultDto>();
            var enumerator = traceResult.resultDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                TraceResultDto traceResultDto = new TraceResultDto();
                time = 0;
                int ti = enumerator.Current.Key;
                RunResultNode runResultNode = enumerator.Current.Value.invokedMethods;
                MethodDto methodDto = ToMethodDto(runResultNode);
                traceResultDto.methodInfoDto = ToMethodDto(runResultNode);
                traceResultDto.ThreadId = ti;
                traceResultDto.Time = time;
                traceResultDtos.Add(traceResultDto);
            }
            return traceResultDtos;
        }
        MethodDto ToMethodDto(RunResultNode runResultNode)
        {
            List<MethodDto> childMethodDtos = new List<MethodDto>();
            foreach (var method in runResultNode.ChildMethods)
            {
                childMethodDtos.Add(ToMethodDto(method));
            }
            MethodDto methodDto = ToMethodDto(runResultNode.ThisMethod);
            methodDto.methodDtos = childMethodDtos;
            return methodDto;
        }

        MethodDto ToMethodDto(RunResult runResult)
        {
            MethodDto methodDto = new MethodDto();
            methodDto.Name = runResult.MethodName;
            methodDto.Time = runResult.ElapsedTime;
            methodDto.Class = runResult.ClassName;
            time += runResult.ElapsedTime;
            return methodDto;
        }
    }
}
