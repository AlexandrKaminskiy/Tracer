using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace TracerLibrary
{
    public class Method
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public long Time { get; set; }
        public Method[] methods { get; set; }

    }
}
