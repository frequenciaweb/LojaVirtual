using System;

namespace LojaVirtual.Domain.Entities
{
    public class Foto
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Caminho { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }
    }
}
