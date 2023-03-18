using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.TrackingField
{
    public class EnabledNotificationRequest
    {
        [XmlElement("FD")]
        public bool? FutureDelivery { get; set; }

        [XmlElement("AL")]
        public bool? AlertDelivery { get; set; }

        [XmlElement("TD")]
        public bool? TodayDelivery { get; set; }

        [XmlElement("UP")]
        public bool? EligiblyForPickup { get; set; }

        [XmlElement("DND")]
        public bool? DeliveryActivity { get; set; }

        [XmlElement("FS")]
        public bool? FirstDisplayableEvent { get; set; }

        [XmlElement("OA")]
        public bool? InTransitAlert { get; set; }
    }
}
