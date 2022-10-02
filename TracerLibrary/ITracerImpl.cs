using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace TracerLibrary
{
    public class ITracerImpl : ITracer
    {

        private TraceResult traceResult;
        private long startTime;
        private long endTime;

        public ITracerImpl()
        {
            traceResult = new TraceResult();
        }
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }
        
        public void StartTrace()
        {
            lock(this) {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                traceResult.resultDictionary.GetOrAdd(threadId, (threadId) => new ThreadTraceResult());
                //startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
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
