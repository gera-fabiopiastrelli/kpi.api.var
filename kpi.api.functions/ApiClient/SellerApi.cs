using System;
using System.Threading.Tasks;

using kpi.api.functions.ApiClient.ResponseModel;

namespace kpi.api.functions.ApiClient
{
    public class SellerApi : BaseApiClient
    {
        private SellerApi()
        {
        }

        public static async Task<ApiResponse<SellerResponse>> GetSellerAsync(int id)
        {
            return await GetAsync<SellerResponse>(string.Format("sellers/{0}", id));
        }
    }
}
