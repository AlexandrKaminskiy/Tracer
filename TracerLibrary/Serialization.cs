using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    namespace Serialization
    {
        internal interface Serialization
        {
            void Serialize(List<Threads> traceResult);
        }
    }
    
}
