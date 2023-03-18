using RPGCor.USPS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace RPGCor.USPS
{
    /// <summary>
    /// Advanced tracking of USPS IDs
    /// </summary>
    public class TrackConfirmRequestAPI
    {
        private List<string> _TrackingNumbers = new List<string>();
        private readonly UspsApi _API;
        private readonly string _APIAccess = "TrackV2";

        public string[] TrackingIds
        {
            get { return _TrackingNumbers.ToArray(); }
        }

        //request limited to 10 ids per request
        public TrackConfirmRequestAPI(UspsApi api)
        {
            _API = api;
        }

        public IPAddress ClientIP { get; set; } = IPAddress.Loopback;
        public string ClientSource { get; set; } = "localhost";
        public int? SourceZip { get; set; }

        public void ClearTrackingNumbers()
        {
            _TrackingNumbers.Clear();
        }

        public void AddTrackingNumber(string tracking)
        {
            tracking = tracking.Trim(' ');
            if (!_TrackingNumbers.Contains(tracking))
                _TrackingNumbers.Add(tracking);
        }

        public void AddTrackingNumbers(string[] trackingNumbers)
        {
            trackingNumbers.All(f => { AddTrackingNumber(f); return true; });
        }

        public TrackFieldResponse QueryStatus()
        {
            var result = new TrackFieldResponse();

            //split into 10 ids per request
            int batchSize = 10;
            for (int i = 0; i < _TrackingNumbers.Count; i += batchSize)
            {
                var subTracking = new TrackFieldRequest() {
                    UserId = _API.APIKey,
                    ClientIp = this.ClientIP,
                    SourceId = this.ClientSource,
                    SourceZip = this.SourceZip
                };
                subTracking.TrackingInfos.AddRange(_TrackingNumbers.Skip(i).Take(batchSize).Select(f => new Model.Tracking.TrackIdAdvanced() { TrackingNumber = f }));
                var response = _API.SubmitRequest<TrackFieldRequest, TrackFieldResponse>(_APIAccess, subTracking);
                result.TrackingInfos.AddRange(response.TrackingInfos);
            }

            return result;
        }
    }
}
