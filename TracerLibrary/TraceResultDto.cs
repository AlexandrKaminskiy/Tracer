using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    internal class TraceResultDto
    {
        public int ThreadId { get; set; }
        public long Time { get; set; }
        public MethodDto methodInfoDto { get; set; }
    }
}
