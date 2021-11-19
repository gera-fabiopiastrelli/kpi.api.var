using System;
using System.Threading.Tasks;

using kpi.api.functions.ApiClient;
using kpi.api.functions.ApiClient.RequestModel;
using kpi.api.functions.ApiClient.ResponseModel;
using kpi.api.functions.Model.Events;

namespace kpi.api.functions.Services
{
    public class SellerService : BaseService
    {
        public static async Task CreateKpiEventAsync(BusinessSegmentEventArgs eventArgs)
        {
            // verify segment code
            if (eventArgs.BusinessSegmentCode == ComercialSituationBusinessSegment)
            {
                // set seller id
                int sellerId = eventArgs.PeopleCode;

                // get seller info
                ApiResponse<SellerResponse> response = await SellerApi.GetSellerAsync(sellerId);

                // verify seller info
                if (response.IsSuccessStatusCode && response.Model != null &&
                    response.Model.BusinessData != null && response.Model.BusinessData.CurrentCycle != null &&
                    response.Model.CommercialStructure != null && response.Model.CommercialStructure.Code != null)
                {
                    // get stracture code
                    int structureCode = (int)response.Model.CommercialStructure.Code;

                    // create kpi event
                    KpiEventRequest kpiEvent = CreateKpiEventRequest(eventArgs);
                    kpiEvent.EventEntityCode = sellerId;
                    kpiEvent.EventEntityAdditionalCode = RevendedorFunction;
                    kpiEvent.Cycle = (int)response.Model.BusinessData.CurrentCycle;

                    // send kpi event to update - old kpi
                    int oldKpi = GetKpiCode(eventArgs.OldValues[0]);
                    if (oldKpi != int.MinValue)
                    {
                        kpiEvent.AmountRealized = decimal.MinusOne;
                        await KpiEventApi.PostKpiEventAsync(structureCode, oldKpi, kpiEvent);
                    }

                    // send kpi event to update - new kpi
                    int newKpi = GetKpiCode(eventArgs.NewValues[0]);
                    if (newKpi != int.MinValue)
                    {
                        kpiEvent.AmountRealized = decimal.One;
                        await KpiEventApi.PostKpiEventAsync(structureCode, newKpi, kpiEvent);
                    }
                }
                else
                {
                    throw new ApplicationException("InvalidSellerResponseModelData");
                }
            }
        }

        private static int GetKpiCode(int segmentValue)
        {
            switch (segmentValue)
            {
                case 0:
                    return PadraoAtivas;
                case 1:
                    return Padrao1CicloSemPedido;
                case 2:
                    return Padrao2CiclosSemPedido;
                case 3:
                    return Padrao3CiclosSemPedido;
                case 4:
                    return Padrao4CiclosSemPedido;
                case 5:
                    return Padrao5CiclosSemPedido;
                case 6:
                    return Padrao6CiclosSemPedido;
                case 7:
                    return Padrao7CiclosSemPedido;
                case 8:
                    return Padrao8CiclosSemPedido;
                case 9:
                    return Padrao9CiclosSemPedido;
                case 10:
                    return Padrao10CiclosSemPedido;
                case 11:
                    return Padrao11CiclosSemPedido;
                case 12:
                    return Padrao12CiclosSemPedido;
                default:
                    return int.MinValue;
            }            
        }
    }
}
