using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model
{
    [XmlRoot(Namespace = "")]
    public class Error
    {
        [XmlElement]
        public long Number { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlElement]
        public string Source { get; set; }

        [XmlElement]
        public string HelpFile { get; set; }

        [XmlElement]
        public string HelpContent { get; set; }
    }
}
