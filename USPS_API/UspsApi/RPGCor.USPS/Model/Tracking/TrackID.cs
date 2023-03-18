using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.Tracking
{
    public class TrackID
    {
        [XmlAttribute("ID")]
        public string TrackingNumber { get; set; }
    }
}
