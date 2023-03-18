using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.Tracking
{
    public class TrackDetail
    {
        [XmlText]
        public string Text { get; set; } = String.Empty;
    }
}
