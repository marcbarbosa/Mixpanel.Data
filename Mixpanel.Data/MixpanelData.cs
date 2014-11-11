using System.IO;
using Mixpanel.Data.Extensions;
using Mixpanel.Data.Interfaces;
using Mixpanel.Data.Models;
using Mixpanel.Data.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Abstractions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Mixpanel.Data
{
    public class MixpanelData : IMixpanelData
    {
        private readonly IConfigurationManager configurationManager;

        private readonly IHttpClient httpClient;

        public string ApiKey { get; private set; }
        public string ApiSecret { get; private set; }
        public string Token { get; private set; }

        public MixpanelData()
            : this(ConfigurationManager.Instance, new HttpClientWrapper())
        {
        }

        public MixpanelData(IConfigurationManager configurationManager, IHttpClient httpClient)
        {
            this.configurationManager = configurationManager;
            this.httpClient = httpClient;

            this.LoadSettings();
        }

        private void LoadSettings()
        {
            ApiKey = this.configurationManager.AppSettings.AppSetting<string>(Constants.SettingKeys.ApiKey, () => { throw new ArgumentNullException(); });

            ApiSecret = this.configurationManager.AppSettings.AppSetting<string>(Constants.SettingKeys.ApiSecret, () => { throw new ArgumentNullException(); });

            Token = this.configurationManager.AppSettings.AppSetting<string>(Constants.SettingKeys.Token, () => { throw new ArgumentNullException(); });
        }

        public async Task<Stream> ExportStream(DateTime from, DateTime to, ICollection<string> events = null, string where = "", string bucket = "")
        {
            var parameters = new NameValueCollection();
            parameters.AddIfNotIsNullOrWhiteSpace("from_date", from.ToString("yyyy-MM-dd"));
            parameters.AddIfNotIsNullOrWhiteSpace("to_date", to.ToString("yyyy-MM-dd"));
            parameters.AddIfNotIsNullOrWhiteSpace("where", where);

            var endpoint = new Endpoint().Create(this.ApiKey, this.ApiSecret)
                                         .ForMethod(MethodEnum.Export)
                                         .WithParameters(parameters)
                                         .Build();

            this.httpClient.TimeOut = TimeSpan.FromHours(1);

            var response = await this.httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }

            return null;
        }

        public async Task<ExportResponse> Export(DateTime from, DateTime to, ICollection<string> events = null, string where = "", string bucket = "")
        {
            var stream = await this.ExportStream(from, to, events, where, bucket);

            var reader = new StreamReader(stream);

            var exportResponse = new ExportResponse();

            while (reader.Peek() > -1)
            {
                exportResponse.Add(JsonConvert.DeserializeObject<Event>(reader.ReadLine()));
            }

            return exportResponse;
        }

        public async Task<EngageResponse> Engage(string where = "", string sessionId = "", int page = 0)
        {
            var parameters = new NameValueCollection();
            parameters.AddIfNotIsNullOrWhiteSpace("where", where);
            parameters.AddIfNotIsNullOrWhiteSpace("session_id", sessionId);
            parameters.AddIfNotIsNullOrWhiteSpace("page", page.ToString());

            var endpoint = new Endpoint().Create(this.ApiKey, this.ApiSecret)
                                         .ForMethod(MethodEnum.Engage)
                                         .WithParameters(parameters)
                                         .Build();

            var response = await this.httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<EngageResponse>();
            }

            return null;
        }
    }
}
