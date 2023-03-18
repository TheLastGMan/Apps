using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.Tracking
{
    public class TrackInfo
    {
        [XmlAttribute("ID")]
        public string TrackingNumber { get; set; } = String.Empty;

        [XmlElement]
        public string TrackSummary { get; set; } = String.Empty;

        [XmlElement("TrackDetail", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
        public List<TrackDetail> TrackingDetails { get; set; } = new List<TrackDetail>();
    }
}
