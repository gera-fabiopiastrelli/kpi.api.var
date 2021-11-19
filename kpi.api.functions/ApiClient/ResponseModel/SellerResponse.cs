using System;
using Newtonsoft.Json;

namespace kpi.api.functions.ApiClient.ResponseModel
{
    public class SellerResponse
    {
        [JsonProperty("businessData")]
        public BusinessDataDO BusinessData { get; set; }

        [JsonProperty("commercialStructure")]
        public CommercialStructureDO CommercialStructure { get; set; }

        public class BusinessDataDO
        {
            [JsonProperty("currentCycle")]
            public int? CurrentCycle { get; set; }
        }

        public class CommercialStructureDO
        {
            [JsonProperty("code")]
            public int? Code { get; set; }
        }
    }
}
