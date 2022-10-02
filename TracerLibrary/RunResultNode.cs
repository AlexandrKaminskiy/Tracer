using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    public class RunResultNode
    {
        RunResultNode(RunResult thisMethod)
        {
            this.thisMethod = thisMethod;
        }

        RunResult thisMethod { get; }
        List<RunResult> childMethods { get; }
    }
}
