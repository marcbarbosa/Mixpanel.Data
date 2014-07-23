using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixpanel.Data.Models
{
    public class Endpoint
    {
        private string baseEndpoint;
        private string method;
        private string parameters;
        private string signature;
        private string apiKey;
        private string apiSecret;
        private string expire;

        //public EndpointBuilder Create(string apiKey, string apiSecret)
        //{
        //    this.apiKey = apiKey;
        //    this.apiSecret = apiSecret;

        //    this.expire = Math.Floor(DateTime.UtcNow.AddSeconds(60).Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();

        //    return this;
        //}
    }
}
