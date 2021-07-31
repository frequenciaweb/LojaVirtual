using System;

namespace LojaVirtual.Domain.Entities
{
    public class ProdutoTag
    {
        public Guid ID { get; set; }

        public Guid TagID { get; set; }
        public Tag Tag { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }
    }
}
