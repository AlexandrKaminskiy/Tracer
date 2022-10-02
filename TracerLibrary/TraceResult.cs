using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
namespace TracerLibrary
{
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadTraceResult> resultDictionary { get; set; }
        public TraceResult()
        {
            resultDictionary = new ConcurrentDictionary<int, ThreadTraceResult>();
        }
        

    }
}
