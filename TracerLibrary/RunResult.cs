using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    struct RunResult
    {
        public RunResult(string methodName, string className, long elapsedTime)
        {
            MethodName = methodName;
            ClassName = className;
            ElapsedTime = elapsedTime;
        }

        public string MethodName { get; }
        public string ClassName { get; }
        public long ElapsedTime { get; }

    
    }
}
