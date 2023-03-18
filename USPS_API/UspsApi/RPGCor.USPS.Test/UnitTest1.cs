using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGCor.USPS.Model;

namespace RPGCor.USPS.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly static string apiKey = "222ROCKB0879";
        private UspsApi api = new UspsApi(apiKey);
        private readonly string _TrackResponseContent =
            "<TrackResponse>" +
                "<TrackInfo ID=\"9400109699937253844310\">" +
                    "<TrackSummary>Your package is moving within the USPS network and is on track to be delivered by the expected delivery date.It is currently in transit to the next facility.</TrackSummary>" +
                    "<TrackDetail>Arrived at USPS Origin Facility, 01/31/2019, 8:47 pm, SAINT PAUL, MN 55131</TrackDetail>" +
                    "<TrackDetail>Departed Post Office, January 31, 2019, 6:37 pm, SAINT PAUL, MN 55125</TrackDetail>" +
                "</TrackInfo>" +
                "<TrackInfo ID=\"9400109699938142214542\">" +
                    "<TrackSummary> Your item was delivered in or at the mailbox at 2:58 pm on January 30, 2019 in HOLLYWOOD, FL 33027.</TrackSummary>" +
                    "<TrackDetail>Out for Delivery, January 30, 2019, 9:31 am, HOLLYWOOD, FL 33027</TrackDetail>" +
                    "<TrackDetail>Sorting Complete, January 30, 2019, 9:21 am, HOLLYWOOD, FL 33027</TrackDetail>" +
                    "<TrackDetail>Arrived at Post Office, January 30, 2019, 7:44 am, HOLLYWOOD, FL 33027</TrackDetail>" +
                    "<TrackDetail>Arrived at USPS Facility, January 30, 2019, 4:47 am, HOLLYWOOD, FL 33027</TrackDetail>" +
                    "<TrackDetail>Departed USPS Regional Facility, 01/30/2019, 4:20 am, OPA LOCKA FL DISTRIBUTION CENTER</TrackDetail>" +
                "</TrackInfo>" +
            "</TrackResponse>";

        [TestMethod]
        public void TrackXml_CreateTrackRequest()
        {
            var trackRequest = new TrackRequest()
            {
                UserId = apiKey
            };
            trackRequest.TrackingIDs.Add(new Model.Tracking.TrackID() { TrackingNumber = "12345ABCDE" });
            trackRequest.TrackingIDs.Add(new Model.Tracking.TrackID() { TrackingNumber = "98765ZYXWV" });
            string content = XmlParser.Serialize(trackRequest);
            Assert.Inconclusive(content);
        }

        [TestMethod]
        public void TrackXml_CreateTrackResponse()
        {
            var trackResponse = new TrackResponse();
            var trackInfo1 = new Model.Tracking.TrackInfo()
            {
                TrackSummary = "Summary",
                TrackingNumber = "123ABC"
            };
            trackInfo1.TrackingDetails.Add(new Model.Tracking.TrackDetail() { Text = "Detail 1" });
            trackInfo1.TrackingDetails.Add(new Model.Tracking.TrackDetail() { Text = "Detail 2" });

            var trackInfo2 = new Model.Tracking.TrackInfo()
            {
                TrackSummary = "Summary2",
                TrackingNumber = "987ZYX"
            };
            trackInfo2.TrackingDetails.Add(new Model.Tracking.TrackDetail() { Text = "Detail X 1" });
            trackInfo2.TrackingDetails.Add(new Model.Tracking.TrackDetail() { Text = "Detail X 2" });

            trackResponse.TrackingInfos.Add(trackInfo1);
            trackResponse.TrackingInfos.Add(trackInfo2);

            string data = XmlParser.Serialize(trackResponse);
            Assert.Inconclusive(data);
        }

        [TestMethod]
        public void TrackXml_ParseSampleResponse()
        {
            var response = XmlParser.DeSerialize<TrackResponse>(_TrackResponseContent);
            Assert.Inconclusive(_TrackResponseContent);
        }

        [TestMethod]
        public void TrackXml_LiveRequest()
        {
            api.TrackRequest().AddTrackingNumber("9400109699937253844310");
            api.TrackRequest().AddTrackingNumber("9400109699938142214542");
            var result = api.TrackRequest().QueryStatus();
            Assert.IsTrue(result.TrackingInfos.Count == 2);
        }

        [TestMethod]
        public void TrackConfirm_CreateV2Request()
        {
            var request = new TrackFieldRequest()
            {
                UserId = apiKey
            };
            request.TrackingInfos.Add(new Model.Tracking.TrackIdAdvanced()
            {
                TrackingNumber = "123ABC",
                DestinationZipCode = 55125,
                MailingDate = new DateTime(2018, 1, 1)
            });
            request.TrackingInfos.Add(new Model.Tracking.TrackIdAdvanced()
            {
                TrackingNumber = "ZYX321"
            });
            var xml = XmlParser.Serialize(request);
            Assert.Inconclusive(xml);
        }

        [TestMethod]
        public void TrackConfirm_LiveV2Request()
        {
            api.TrackConfirmRequest().AddTrackingNumber("9400109699938213993239");
            var result = api.TrackConfirmRequest().QueryStatus();
            Assert.IsTrue(result.TrackingInfos.Count == 4);
        }
    }
}
