using RPGCor.USPS.Model.Tracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model
{
    //222ROCKB0879
    /*
     http://production.shippingapis.com/ShippingAPI.dll?API=TrackV2&XML=
     <?xml version="1.0" encoding="UTF-8"?>
     <TrackRequest USERID="222ROCKB0879">
        <TrackID ID="9400109699937253844310"/>
        <TrackID ID="9400109699938142214542"/>
     </TrackRequest>
    */
    [XmlType(AnonymousType = true)]
    [XmlRoot("TrackRequest", Namespace = "", IsNullable = false)]
    public class TrackRequest
    {
        [XmlAttribute("USERID")]
        public string UserId { get; set; } = String.Empty;

        [XmlElement("TrackID", Form = XmlSchemaForm.Unqualified)]
        public List<TrackID> TrackingIDs { get; set; } = new List<TrackID>();
    }
}
