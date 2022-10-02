using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    internal class RunResult
    {
        public RunResult(string methodName, string className, long elapsedTime)
        {
            MethodName = methodName;
            ClassName = className;
            ElapsedTime = elapsedTime;
        }
        public RunResult()
        {

        }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public long ElapsedTime { get; set; }

    
    }
}
