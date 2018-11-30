using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace D2RuneHelper3.Model
{
    public class D2Stat
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
}
