using Mixpanel.Data.Interfaces;
using Mixpanel.Data.ResponseModels;
using System;
using System.Configuration.Abstractions;
using System.Threading.Tasks;

namespace Mixpanel.Data
{
    public class MixpanelData : IMixpanelData
    {
        private readonly IConfigurationManager configurationManager;

        public string ApiKey { get; private set; }
        public string ApiSecret { get; private set; }
        public string Token { get; private set; }

        public MixpanelData()
            : this(ConfigurationManager.Instance)
        {
        }

        public MixpanelData(IConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager;

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

        public Task<ExportResponse> Export(DateTime from, DateTime to, System.Collections.Generic.ICollection<string> events = null, string where = "", string bucket = "")
        {
            throw new NotImplementedException();
        }

        public Task<EngageResponse> Engage(string where, string sessionId, int page)
        {
            throw new NotImplementedException();
        }
    }
}
