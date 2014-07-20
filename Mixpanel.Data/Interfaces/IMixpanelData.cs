using Mixpanel.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mixpanel.Data.Interfaces
{
    public interface IMixpanelData
    {
        Task<ExportResponse> Export(DateTime from, DateTime to, ICollection<string> events = null, string where = "", string bucket = "");

        Task<EngageResponse> Engage(string where, string sessionId, int page);
    }
}
