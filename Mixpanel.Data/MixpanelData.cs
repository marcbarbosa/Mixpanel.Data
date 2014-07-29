using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using Mixpanel.Data.Extensions;
using Mixpanel.Data.Interfaces;
using Mixpanel.Data.Models;
using Mixpanel.Data.ResponseModels;
using System;
using System.Configuration.Abstractions;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

            LoadSettings();
        }

        private void LoadSettings()
        {
            ApiKey = configurationManager.AppSettings.AppSetting<string>(Constants.SettingKeys.ApiKey,
                () => { throw new ArgumentNullException(); });

            ApiSecret = configurationManager.AppSettings.AppSetting<string>(Constants.SettingKeys.ApiSecret,
                () => { throw new ArgumentNullException(); });

            Token = configurationManager.AppSettings.AppSetting<string>(Constants.SettingKeys.Token,
                () => { throw new ArgumentNullException(); });
        }

        public async Task<ExportResponse> Export(DateTime from, DateTime to, ICollection<string> events = null, string where = "", string bucket = "")
        {
            var parameters = new NameValueCollection();
            parameters.AddIfNotIsNullOrWhiteSpace("from_date", from.ToString("yyyy-MM-dd"));
            parameters.AddIfNotIsNullOrWhiteSpace("to_date", to.ToString("yyyy-MM-dd"));

            var endpoint = new Endpoint().Create(this.ApiKey, this.ApiSecret)
                                         .ForMethod(MethodEnum.Export)
                                         .WithParamaters(parameters)
                                         .Build();

            var response = await httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var eventDump = await response.Content.ReadAsStringAsync();

                var eventList = (from evt in eventDump.Split('\n')
                                 select JsonConvert.DeserializeObject<Event>(evt)).ToList();

                var exportResponse = new ExportResponse();

                eventList.ForEach(exportResponse.Add);

                return exportResponse;
            }

            return null;
        }

        public async Task<EngageResponse> Engage(string where = "", string sessionId = "", int page = 0)
        {
            throw new NotImplementedException();
        }
    }
}
