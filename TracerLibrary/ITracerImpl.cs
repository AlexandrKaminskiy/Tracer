using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TracerLibrary
{
    public class ITracerImpl : ITracer
    {
        private List<ITracer> ITracers { set; get; }
        private TraceResult traceResult;
        private long startTime;
        private long endTime;

        public ITracerImpl()
        {
            ITracers = new List<ITracer>();
        }
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public void StartTrace()
        {
            lock(this) {
                startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }

        public void StopTrace()
        {
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            StackTrace stackTrace = new StackTrace();
            var invoker = stackTrace.GetFrame(1).GetMethod();
            string methodName = invoker.Name;
            string className = invoker.DeclaringType.Name;
            long elapsedTime = endTime - startTime;
        }

    }
}
