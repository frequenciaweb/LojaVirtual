using System;

namespace LojaVirtual.Domain.Entities
{
    public class ListaDesejo
    {
        public Guid ID { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public Guid ClienteID { get; set; }
        public Cliente Cliente { get; set; }

    }
}
