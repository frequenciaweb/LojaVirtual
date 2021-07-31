using System;

namespace LojaVirtual.Domain.Entities
{
    public class Desconto
    {
        public Guid ID { get; set; }
        public DateTime Validade { get; set; }

        public decimal Valor { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }
    }
}
