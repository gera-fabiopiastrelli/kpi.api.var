using System;

namespace kpi.api.functions.Model.Events
{
    public class OrderEventArgs : BaseEventArgs
    {
        /// <summary>
        /// Número do pedido
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Código da pessoa
        /// </summary>
        public int RepresentativeCode { get; set; }

        /// <summary>
        /// Código da função
        /// </summary>
        public int FunctionCode { get; set; }

        /// <summary>
        /// Estrutura comercial
        /// </summary>
        public Structure BusinessStructure { get; set; }

        /// <summary>
        /// Classe estrutura
        /// </summary>
        public class Structure
        {
            /// <summary>
            /// Código
            /// </summary>
            public int Code { get; set; }
        }

        /// <summary>
        /// Quantidade de itens
        /// </summary>
        public int? ItemsQuantity { get; set; }

        /// <summary>
        /// Pontos
        /// </summary>
        public int? PointsQuantity { get; set; }

        /// <summary>
        /// Valor de tabela
        /// </summary>
        public decimal? TableValue { get; set; }

        /// <summary>
        /// Valor praticado
        /// </summary>
        public decimal? MarketValue { get; set; }

        /// <summary>
        /// Valor líquido
        /// </summary>
        public decimal? NetValue { get; set; }

        /// <summary>
        /// Campanha aprovação
        /// </summary>
        public int? ApprovalCycle { get; set; }

        /// <summary>
        /// Campanha de cancelamento
        /// </summary>
        public int? CancellationCycle { get; set; }
    }
}
