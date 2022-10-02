using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    public class ThreadTraceResult
    {
        Stack<RunResultNode> methodsStack { get; set; }
        RunResultNode invokedMethods { get; set; }
        public ThreadTraceResult()
        {
            methodsStack = new Stack<RunResultNode>();
        }
        
    }
}
