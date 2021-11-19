using System;
using System.Threading.Tasks;

using kpi.api.functions.ApiClient;
using kpi.api.functions.ApiClient.RequestModel;
using kpi.api.functions.ApiClient.ResponseModel;
using kpi.api.functions.Model.Events;

namespace kpi.api.functions.Services
{
    public class OrderService : BaseService
    {
        public static async Task CreateKpiEventAsync(OrderEventArgs orderEventArgs, bool cancel)
        {
            // get stracture code
            int structureCode = orderEventArgs.BusinessStructure.Code;

            // create kpi event
            KpiEventRequest kpiEvent = CreateKpiEventRequest(orderEventArgs);
            kpiEvent.EventEntityCode = orderEventArgs.OrderNumber;
            kpiEvent.Cycle = (int)(cancel ? orderEventArgs.CancellationCycle : orderEventArgs.ApprovalCycle);

            // send kpi event to update
            await CreateKpiEventAsync(cancel, structureCode, kpiEvent, PadraoPedido, decimal.One);
            await CreateKpiEventAsync(cancel, structureCode, kpiEvent, PadraoFaturamento, (decimal)orderEventArgs.NetValue);
            await CreateKpiEventAsync(cancel, structureCode, kpiEvent, PadraoTabela, (decimal)orderEventArgs.TableValue);
            await CreateKpiEventAsync(cancel, structureCode, kpiEvent, PadraoPraticado, (decimal)orderEventArgs.MarketValue);
            await CreateKpiEventAsync(cancel, structureCode, kpiEvent, PadraoItensPedido, (decimal)orderEventArgs.ItemsQuantity);
        }

        private static async Task<ApiResponse<KpiEventResponse>> CreateKpiEventAsync(bool cancel, int structureCode, KpiEventRequest kpiEvent, int kpiCode, decimal value)
        {
            kpiEvent.AmountRealized = cancel ? -value : value;
            return await KpiEventApi.PostKpiEventAsync(structureCode, kpiCode, kpiEvent);
        }
    }
}
