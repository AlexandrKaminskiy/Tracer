using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    public struct TraceResult
    {
        public TraceResult(string methodName, string className, long elapsedTime) : this()
        {
            MethodName = methodName;
            ClassName = className;
            ElapsedTime = elapsedTime;
        }

        string MethodName { get; }
        string ClassName { get; }
        public long ElapsedTime { get; }
    }

    public interface ITracer
    {
        void StartTrace();
    
        void StopTrace();
    
        public TraceResult GetTraceResult();
    }
}
