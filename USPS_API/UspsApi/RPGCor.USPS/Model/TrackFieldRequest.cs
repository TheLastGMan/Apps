using RPGCor.USPS.Model.Tracking;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model
{
    [XmlRoot(Namespace = "")]
    public class TrackFieldRequest
    {
        [XmlAttribute("USERID")]
        public string UserId { get; set; } = String.Empty;

        [XmlElement]
        public string Revision { get; set; } = "1";

        [XmlElement("ClientIp")]
        public string ClientIpRaw { get; set; } = "127.0.0.1";

        [XmlElement]
        public string SourceId { get; set; } = "localhost";

        [XmlElement("SourceZip")]
        public string SourceZipRaw { get; set; }

        [XmlElement("TrackID", Form = XmlSchemaForm.Unqualified)]
        public List<TrackIdAdvanced> TrackingInfos { get; set; } = new List<TrackIdAdvanced>();

        [XmlIgnore]
        public IPAddress ClientIp
        {
            get { return IPAddress.Parse(ClientIpRaw); }
            set { ClientIpRaw = value.ToString(); }
        }

        [XmlIgnore]
        public int? SourceZip
        {
            get
            {
                if(SourceZipRaw == null)
                    return null;
                return int.Parse(SourceZipRaw);
            }
            set
            {
                if(value != null)
                {
                    if(value < 0 || value > 99999)
                        throw new ArgumentOutOfRangeException("value must be in the range [0, 99999]");
                    SourceZipRaw = value.ToString().PadLeft(5, ' ');

                } else
                {
                    SourceZipRaw = null;
                }
            }
        }
    }
}
