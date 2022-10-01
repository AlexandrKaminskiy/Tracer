using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TracerLibrary
{
    class ITracerImpl : ITracer
    {
        private TraceResult traceResult;
        private long startTime;
        private long endTime;

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public void StartTrace()
        {
            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public void StopTrace()
        {
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            StackTrace stackTrace = new StackTrace();
            var invoker = stackTrace.GetFrame(1).GetMethod();
            string methodName = invoker.Name;
            string className = invoker.DeclaringType.Name;
            long elapsedTime = endTime - startTime;
            traceResult = new TraceResult(methodName, className, elapsedTime);
        }
    }
}
