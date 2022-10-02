using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    public class ThreadTraceResult
    {
        public Stack<RunResultNode> methodsStack { get; set; }
        public RunResultNode invokedMethods { get; set; }
        public ThreadTraceResult()
        {
            methodsStack = new Stack<RunResultNode>();
        }
        
    }
}
