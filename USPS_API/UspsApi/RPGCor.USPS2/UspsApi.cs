using RPGCor.USPS.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RPGCor.USPS
{
    public class UspsApi
    {
        public string APIKey { get; private set; }
        public Environment HostEnvironment { get; private set; }

        public UspsApi(string apiKey, Environment environment = Environment.Production)
        {
            APIKey = apiKey;
            HostEnvironment = environment;
        }

        public TrackRequestAPI CreateTrackRequest()
        {
            return new TrackRequestAPI(this);
        }

        private TrackRequestAPI _TrackRequestAPI;
        public TrackRequestAPI TrackRequest()
        {
            return _TrackRequestAPI ?? (_TrackRequestAPI = CreateTrackRequest());
        }

        public TrackConfirmRequestAPI CreateTrackConfirmRequest()
        {
            return new TrackConfirmRequestAPI(this);
        }

        private TrackConfirmRequestAPI _TrackConfirmAPI;
        public TrackConfirmRequestAPI TrackConfirmRequest()
        {
            return _TrackConfirmAPI ?? (_TrackConfirmAPI = CreateTrackConfirmRequest());
        }

        internal U SubmitRequest<T, U>(string apiName, T body)
            where T : class
            where U : class
        {
            //setup client
            var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 5)
            };

            //convert body to XML and load response
            string bodyContent = XmlParser.Serialize(body);

            //generate URL
            var baseUrl = $"https://{ (HostEnvironment == Environment.Staging ? "stg-" : "") }secure.shippingapis.com/ShippingAPI.dll?API={ apiName }&XML={ bodyContent }";

            //load response
            var responseBody = client.GetStringAsync(baseUrl).Result;

            //check for error by processing it as an error record
            try
            {
                var errorBody = XmlParser.DeSerialize<Error>(responseBody);
                throw new Exception(errorBody.Description + " | " + errorBody.Source);
            }
            catch
            {
                //unable to convert to Error response, assume it is valid
            }

            //convert response to output type
            var response = XmlParser.DeSerialize<U>(responseBody);
            return response;
        }
    }
}
