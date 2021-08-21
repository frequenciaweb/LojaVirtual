using System;

namespace LojaVirtual.Domain.Entities
{
    public class PedidoItem
    {
        public Guid ID { get; set; }

        public Guid PedidoID { get; set; }
        public Pedido Pedido { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }  
        public decimal ValorTotal { get; set; } 
    }
}
