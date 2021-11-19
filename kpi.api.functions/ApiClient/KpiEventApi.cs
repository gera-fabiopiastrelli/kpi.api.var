using System;
using System.Threading.Tasks;

using kpi.api.functions.ApiClient.RequestModel;
using kpi.api.functions.ApiClient.ResponseModel;

namespace kpi.api.functions.ApiClient
{
    public class KpiEventApi : BaseApiClient
    {
        private KpiEventApi()
        {
        }

        public static async Task<ApiResponse<KpiEventResponse>> PostKpiEventAsync(int structureCode, int kpiCode, KpiEventRequest kpiEvent)
        {
            return await PostAsync<KpiEventResponse, KpiEventRequest>(string.Format("commercialStructures/{0}/kpis/{1}/event", structureCode, kpiCode), kpiEvent);
        }
    }
}
