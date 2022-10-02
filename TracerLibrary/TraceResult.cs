using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;
namespace TracerLibrary
{
    public class TraceResult
    {
        ConcurrentDictionary<string, ThreadTraceResult> traceResult { get; set; }
    }
}
