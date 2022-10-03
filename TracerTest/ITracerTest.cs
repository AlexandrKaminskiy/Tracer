using System;
using Xunit;
using TracerLibrary;

namespace TracerTest
{
    public class ITracerTest
    {
        ITracer tracer;
        
        public ITracerTest()
        {
            tracer = new Tracer();
        }

        [Fact]
        public void StartTrace()
        {
            tracer.StartTrace();
            Assert.True(true);
        }

        [Fact]
        public void StopTraceEmptyStack()
        {
            Assert.Throws<InvalidOperationException>(() => tracer.StopTrace());
        }

        [Fact]
        public void StopTrace()
        {
            tracer.StartTrace();
            tracer.StopTrace();
            Assert.True(true);
        }

        [Fact]
        public void GetTraceResult()
        {
            tracer.GetTraceResult();
            Assert.True(true);
        }

    }
}
