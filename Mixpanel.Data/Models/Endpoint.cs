using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mixpanel.Data.Extensions;
using Mixpanel.Data.Facts.Extensions;
using Simplify.Cryptography;

namespace Mixpanel.Data.Models
{
    public class Endpoint
    {
        public string BaseEndpoint { get; private set; }
        public string Method { get; private set; }
        public string Parameters { get; private set; }
        public string Signature { get; private set; }
        public string ApiKey { get; private set; }
        public string ApiSecret { get; private set; }
        public string Expire { get; private set; }

        public Endpoint Create(string apiKey, string apiSecret)
        {
            this.ApiKey = apiKey;
            this.ApiSecret = apiSecret;
            this.Expire = DateTime.UtcNow.AddSeconds(60).ToUnixTimestamp().ToString();

            return this;
        }

        public Endpoint ForMethod(MethodEnum method)
        {
            this.Method = method.ToDescriptionString();
            this.BaseEndpoint = "http://mixpanel.com/api/2.0/";

            if (method == MethodEnum.Export)
            {
                this.BaseEndpoint = "http://data.mixpanel.com/api/2.0/";
            }

            return this;
        }

        public Endpoint WithParamaters(NameValueCollection parameters)
        {
            parameters.Add("api_key", this.ApiKey);
            parameters.Add("expire", this.Expire);
            this.Parameters = parameters.ToQueryString();

            this.Signature = CalculateSignature(parameters);

            return this;
        }

        public string Build()
        {
            return this.ToString();
        }

        private string CalculateSignature(NameValueCollection parameters)
        {
            var sortedParameters = new SortedDictionary<string, string>(parameters.AllKeys.ToDictionary(key => key, key => parameters[key]));

            var querystringWithNoAmpersand = sortedParameters.ToQueryString().Replace("&", string.Empty);

            return MD5.GetHash(string.Concat(querystringWithNoAmpersand, this.ApiSecret));
        }

        public override string ToString()
        {
            var endpoint = string.Format("{0}{1}/?{2}", this.BaseEndpoint, this.Method, this.Parameters);

            if (!string.IsNullOrWhiteSpace(this.Signature))
            {
                endpoint = string.Concat(endpoint, "&sig=", this.Signature);
            }

            return endpoint;
        }
    }
}
