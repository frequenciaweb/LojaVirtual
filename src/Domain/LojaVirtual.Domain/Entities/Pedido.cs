using LojaVirtual.Domain.Enums;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Pedido
    {
        public Guid ID { get; set; }
        public decimal Total { get; set; }
        public decimal TotalFrete { get; set; }
        public decimal TotalProdutos { get; set; }
        public decimal TotalDesconto { get; set; }

        public Guid? CupomID { get; set; }
        public Cupom Cupom { get; set; }

        public EnumFormaPagamento FormaPagamento { get; set; }
        public EnumStatusPedido StatusPedido { get; set; }
        public EnumStatusEntrega StatusEntrega { get; set; }

        public DateTime Data { get; set; }

        public Guid ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public List<PedidoItem> Itens { get; set; }

    }
}
