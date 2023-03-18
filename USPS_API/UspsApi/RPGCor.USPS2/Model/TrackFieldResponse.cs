using RPGCor.USPS.Model.TrackingField;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model
{
    [XmlRoot("TrackResponse", Namespace = "")]
    public class TrackFieldResponse
    {
        [XmlElement("TrackInfo", Form = XmlSchemaForm.Unqualified)]
        public List<TrackInfo> TrackingInfos { get; set; } = new List<TrackInfo>();
    }
}
