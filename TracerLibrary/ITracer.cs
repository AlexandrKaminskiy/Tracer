using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    public struct TraceResult
    {
        string methodName;
        string className;
        long runTime;

        public TraceResult(string methodName, string className, long runTime)
        {
            this.methodName = methodName;
            this.className = className;
            this.runTime = runTime;
        }
    }

    public interface ITracer
    {
        void StartTrace();​
    
        void StopTrace();​
    
        TraceResult GetTraceResult();
    }
}
