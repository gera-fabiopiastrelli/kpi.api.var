using System;

using kpi.api.functions.Model.Events;
using kpi.api.functions.ApiClient.RequestModel;

namespace kpi.api.functions.Services
{
    public class BaseService
    {
        // segmentos comerciais
        protected const int ComercialSituationBusinessSegment = 1;

        // funcoes
        protected const int RevendedorFunction = 1;

        // kpis codes - pedido
        protected const int PadraoPedido = 1000;
        protected const int PadraoFaturamento = 1001;
        protected const int PadraoTabela = 1002;
        protected const int PadraoPraticado = 1003;
        protected const int PadraoItensPedido = 1007;

        // kpi codes - canal
        protected const int PadraoAtivas = 900;
        protected const int Padrao1CicloSemPedido = 901;
        protected const int Padrao2CiclosSemPedido = 902;
        protected const int Padrao3CiclosSemPedido = 903;
        protected const int Padrao4CiclosSemPedido = 904;
        protected const int Padrao5CiclosSemPedido = 905;
        protected const int Padrao6CiclosSemPedido = 906;
        protected const int Padrao7CiclosSemPedido = 907;
        protected const int Padrao8CiclosSemPedido = 908;
        protected const int Padrao9CiclosSemPedido = 909;
        protected const int Padrao10CiclosSemPedido = 910;
        protected const int Padrao11CiclosSemPedido = 911;
        protected const int Padrao12CiclosSemPedido = 912;

        static BaseService()
        {
        }

        protected static KpiEventRequest CreateKpiEventRequest(BaseEventArgs eventArgs)
        {
            return new KpiEventRequest()
            {
                EventGuid = eventArgs.Jti,
                EventType = eventArgs.Sub,
                EventDate = eventArgs.Iat
            };
        }
    }
}
