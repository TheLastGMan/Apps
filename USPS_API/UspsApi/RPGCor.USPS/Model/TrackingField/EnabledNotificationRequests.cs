using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.TrackingField
{
    public class EnabledNotificationRequests
    {
        [XmlElement("SMS")]
        public EnabledNotificationRequest Sms { get; set; }

        [XmlElement("EMAIL")]
        public EnabledNotificationRequest Email { get; set; }
    }
}
