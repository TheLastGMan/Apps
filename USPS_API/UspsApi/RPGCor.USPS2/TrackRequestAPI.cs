using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RPGCor.USPS.Model;
using RPGCor.USPS.Model.Tracking;

namespace RPGCor.USPS
{
    /// <summary>
    /// Basic tracking of USPS IDs
    /// </summary>
    public class TrackRequestAPI
    {
        private List<string> _TrackingNumbers = new List<string>();
        private readonly UspsApi _API;
        private readonly string _APIAccess = "TrackV2";

        public string[] TrackingIds
        {
            get { return _TrackingNumbers.ToArray(); }
        }

        //request limited to 10 ids per request
        public TrackRequestAPI(UspsApi api)
        {
            _API = api;
        }

        public void ClearTrackingNumbers()
        {
            _TrackingNumbers.Clear();
        }

        public void AddTrackingNumber(string tracking)
        {
            if (!_TrackingNumbers.Contains(tracking))
                _TrackingNumbers.Add(tracking);
        }

        public void AddTrackingNumbers(string[] trackingNumbers)
        {
            trackingNumbers.All(f => { AddTrackingNumber(f); return true; });
        }

        public TrackResponse QueryStatus()
        {
            var result = new TrackResponse();

            //split into 10 ids per request
            int batchSize = 10;
            for (int i = 0; i < _TrackingNumbers.Count; i += batchSize)
            {
                var subTracking = new TrackRequest() { UserId = _API.APIKey };
                subTracking.TrackingIDs.AddRange(_TrackingNumbers.Skip(i).Take(batchSize).Select(f => new TrackID() { TrackingNumber = f }));
                var response = _API.SubmitRequest<TrackRequest, TrackResponse>(_APIAccess, subTracking);
                result.TrackingInfos.AddRange(response.TrackingInfos);
            }

            return result;
        }
    }
}
