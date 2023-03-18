using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.TrackingField
{
    public class TrackSummary
    {
        [XmlElement]
        public string EventTime { get; set; } = String.Empty;

        [XmlElement]
        public string EventDate { get; set; } = String.Empty;

        [XmlElement]
        public string Event { get; set; } = String.Empty;

        [XmlElement]
        public string EventCity { get; set; } = String.Empty;

        [XmlElement]
        public string EventState { get; set; } = String.Empty;

        [XmlElement]
        public string EventZIPCode { get; set; } = String.Empty;

        [XmlElement]
        public string EventCountry { get; set; }

        [XmlElement]
        public string FirmName { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string AuthorizedAgent { get; set; }

        [XmlElement]
        public string EventCode { get; set; }

        [XmlElement]
        public string ActionCode { get; set; }

        [XmlElement]
        public string ReasonCode { get; set; }

        [XmlElement]
        public bool? GeoCertified { get; set; }
    }
}
