using System;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.Tracking
{
    public class TrackIdAdvanced
    {
        [XmlAttribute("ID")]
        public string TrackingNumber { get; set; } = String.Empty;

        [XmlElement("DestinationZipCode")]
        public string DestinationZipCodeRaw { get; set; }

        [XmlElement("MailingDate")]
        public string MailingDateRaw { get; set; }

        [XmlIgnore]
        public int? DestinationZipCode
        {
            get
            {
                if(DestinationZipCode == null)
                    return null;
                return int.Parse(MailingDateRaw);
            }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Value cannot be null");
                if(value < 0 || value > 99999)
                    throw new ArgumentOutOfRangeException("Value must be in the range [0, 99999]");
                DestinationZipCodeRaw = value.ToString().PadLeft(5, ' ');
            }
        }

        [XmlIgnore]
        public DateTime? MailingDate
        {
            get
            {
                if(MailingDateRaw == null)
                    return null;
                return DateTime.Parse(MailingDateRaw);
            }
            set { MailingDateRaw = value?.ToString("yyyy-MM-dd"); }
        }
    }
}
