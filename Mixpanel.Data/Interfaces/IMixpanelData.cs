using Mixpanel.Data.ResponseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mixpanel.Data.Interfaces
{
    public interface IMixpanelData
    {
        Task<Stream> ExportStream(DateTime from, DateTime to, ICollection<string> events = null, string where = "", string bucket = "");
        
        Task<ExportResponse> Export(DateTime from, DateTime to, ICollection<string> events = null, string where = "", string bucket = "");

        Task<EngageResponse> Engage(string where = "", string sessionId = "", int page = 0);
    }
}
