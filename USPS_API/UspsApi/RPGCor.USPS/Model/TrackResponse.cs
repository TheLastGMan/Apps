using RPGCor.USPS.Model.Tracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPGCor.USPS.Model
{
    /*
    <TrackResponse>
	    <TrackInfo ID="9400109699937253844310">
		    <TrackSummary>Your package is moving within the USPS network and is on track to be delivered by the expected delivery date. It is currently in transit to the next facility.</TrackSummary>
		    <TrackDetail>Arrived at USPS Origin Facility, 01/31/2019, 8:47 pm, SAINT PAUL, MN 55131</TrackDetail>
		    <TrackDetail>Departed Post Office, January 31, 2019, 6:37 pm, SAINT PAUL, MN 55125</TrackDetail>
	    </TrackInfo>
	    <TrackInfo ID="9400109699938142214542">
		    <TrackSummary>Your item was delivered in or at the mailbox at 2:58 pm on January 30, 2019 in HOLLYWOOD, FL 33027.</TrackSummary>
		    <TrackDetail>Out for Delivery, January 30, 2019, 9:31 am, HOLLYWOOD, FL 33027</TrackDetail>
		    <TrackDetail>Sorting Complete, January 30, 2019, 9:21 am, HOLLYWOOD, FL 33027</TrackDetail>
		    <TrackDetail>Arrived at Post Office, January 30, 2019, 7:44 am, HOLLYWOOD, FL 33027</TrackDetail>
		    <TrackDetail>Arrived at USPS Facility, January 30, 2019, 4:47 am, HOLLYWOOD, FL 33027</TrackDetail>
		    <TrackDetail>Departed USPS Regional Facility, 01/30/2019, 4:20 am, OPA LOCKA FL DISTRIBUTION CENTER		</TrackDetail>
	    </TrackInfo>
    </TrackResponse>
    */

    [XmlType(AnonymousType = true)]
    [XmlRoot("TrackResponse", Namespace = "", IsNullable = false)]
    public class TrackResponse
    {
        [XmlElement("TrackInfo", Form = XmlSchemaForm.Unqualified)]
        public List<TrackInfo> TrackingInfos { get; set; } = new List<TrackInfo>();
    }
}
