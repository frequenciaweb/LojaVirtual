using System;

namespace LojaVirtual.Domain.Entities
{
    public class Foto
    {
        public Guid ID { get; set; }
        public string Caminho { get; set; }
        public string Nome { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }
    }
}
