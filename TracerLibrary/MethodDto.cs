using System;
using System.Collections.Generic;
using System.Text;

namespace TracerLibrary
{
    internal class MethodDto
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time { get; set; }
        public List<MethodDto> methodDtos { get; set; }
    }
}
