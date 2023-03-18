using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model.TrackingField
{
    public class TrackInfo
    {
        [XmlAttribute("ID")]
        public string TrackingNumber { get; set; } = String.Empty;

        /// <summary>
        /// Set only if there is an error with a tracking number
        /// </summary>
        [XmlElement]
        public Error Error { get; set; }

        [XmlIgnore]
        public bool HasError { get { return Error != null; } }

        [XmlElement]
        public string AdditionalInfo { get; set; }

        [XmlElement]
        public string ADPScripting { get; set; }

        [XmlElement("ARCHDATA")]
        public string ArchData { get; set; }

        [XmlElement]
        public string ArchiveRestoreInfo { get; set; }

        [XmlElement]
        public string AssociatedLabel { get; set; }

        [XmlElement]
        public string Class { get; set; }

        [XmlElement]
        public string ClassOfMailCode { get; set; }

        [XmlElement]
        public string DeliveryNotificationDate { get; set; }

        [XmlElement]
        public string DestinationCity { get; set; }

        [XmlElement]
        public string DestinationCountryCode { get; set; }

        [XmlElement]
        public string DestinationState { get; set; }

        [XmlElement]
        public string DestinationZip { get; set; }

        [XmlElement]
        public string EditedLabelID { get; set; }

        [XmlElement]
        public string EmailEnabled { get; set; }

        [XmlElement]
        public string ExpectedDeliveryDate { get; set; }

        [XmlElement]
        public string GuaranteedDeliveryDate { get; set; }

        [XmlElement]
        public string GuaranteedDeliveryTime { get; set; }

        [XmlElement]
        public string GuaranteedDetails { get; set; }

        [XmlElement]
        public string KahalaIndicator { get; set; }

        [XmlElement]
        public string MailTypeCode { get; set; }

        [XmlElement("MPDATE")]
        public string MpDate { get; set; }

        [XmlElement("MPSUFFIX")]
        public string MpSuffix { get; set; }

        [XmlElement]
        public string OriginCity { get; set; }

        [XmlElement]
        public string OriginCountryCode { get; set; }

        [XmlElement]
        public string OriginState { get; set; }

        [XmlElement]
        public string OriginZip { get; set; }

        [XmlElement("PodEnabled")]
        public bool? ProofOfDeliveryEnabled { get; set; }

        [XmlElement]
        public string PredictedDeliveryDate { get; set; }

        [XmlElement]
        public string PredictedDeliveryTime { get; set; }

        [XmlElement("PDWStart")]
        public string PredictedDeliveryWindowStart { get; set; }

        [XmlElement("PDWEnd")]
        public string PredictedDeliveryWindowEnd { get; set; }

        [XmlElement("RelatedRRID")]
        public string RelatedReturnReceiptId { get; set; }

        [XmlElement]
        public bool? RestoreEnabled { get; set; }

        [XmlElement]
        public bool? RRAMenabled { get; set; }

        [XmlElement("RreEnabled")]
        public bool? ReturnReceiptElectronicServiceEnabled { get; set; }

        [XmlElement]
        public string Service { get; set; }

        [XmlElement]
        public string ServiceTypeCode { get; set; }

        [XmlElement]
        public string Status { get; set; }

        [XmlElement]
        public string StatusCategory { get; set; }

        [XmlElement("TABLECODE")]
        public string InternalTableCode { get; set; }

        [XmlElement("TpodEnabled")]
        public bool? TrackingProofOfDeliveryEnabled { get; set; }

        [XmlElement]
        public string ValueofArticle { get; set; }

        [XmlElement]
        public EnabledNotificationRequests EnabledNotificationRequests { get; set; }

        [XmlElement]
        public TrackSummary TrackSummary { get; set; } = new TrackSummary();

        [XmlElement("TrackDetail", Form = XmlSchemaForm.Unqualified)]
        public List<TrackDetail> TrackDetails { get; set; } = new List<TrackDetail>();
    }
}
