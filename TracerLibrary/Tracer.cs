using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using TracerLibrary.Serialization;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {

        private TraceResult traceResult;
        public Tracer()
        {
            traceResult = new TraceResult();
        }
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }
        
        public void StartTrace()
        {
            lock(this) 
            {
                RunResultNode invokedMethod = new RunResultNode();
                int threadId = Thread.CurrentThread.ManagedThreadId;
                ThreadTraceResult ttr = traceResult.resultDictionary.GetOrAdd(threadId, (threadId) => new ThreadTraceResult());
                ttr.methodsStack.Push(invokedMethod);

            }
        }

        public void StopTrace()
        {
            lock (this)
            {
                long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                int threadId = Thread.CurrentThread.ManagedThreadId;
                ThreadTraceResult ttr = traceResult.resultDictionary.GetOrAdd(threadId, (threadId) => new ThreadTraceResult());
                RunResultNode endedMethod = ttr.methodsStack.Pop();
                if (ttr.methodsStack.Count != 0)
                {
                    RunResultNode invoker = ttr.methodsStack.Peek();
                    endedMethod.ParentMethod = invoker;
                    invoker.ChildMethods.Add(endedMethod);
                } 
                else
                {
                    ttr.invokedMethods = endedMethod;
                }
                
                StackTrace stackTrace = new StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                string methodName = method.Name;
                string className = method.DeclaringType.Name;
                long elapsedTime = endTime - endedMethod.AddingToStackTime;

                endedMethod.ThisMethod = new RunResult(methodName, className, elapsedTime);
            }
        }

    }
}
