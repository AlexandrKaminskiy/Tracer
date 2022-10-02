using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
namespace TracerLibrary
{
    public class TraceResult
    {
        internal ConcurrentDictionary<int, ThreadTraceResult> resultDictionary { get; set; }
        internal TraceResult()
        {
            resultDictionary = new ConcurrentDictionary<int, ThreadTraceResult>();
        }
        

    }
}
