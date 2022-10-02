using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    internal class RunResultNode
    {
        public RunResultNode()
        {
            ChildMethods = new List<RunResultNode>();
            AddingToStackTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
        public long AddingToStackTime { get; }
        public RunResult ThisMethod { set; get; }
        public RunResultNode ParentMethod { set; get; }
        public List<RunResultNode> ChildMethods { get; }
    }
}
