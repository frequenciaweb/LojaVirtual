using System;

namespace LojaVirtual.Domain.Entities
{
    public class Comentario
    {
        public Guid ID { get; set; }

        public Guid ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public int Avaliacao { get; set; }

        public string Texto { get; set; }

        public Guid CLienteID { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime Cadastro { get; set; }
    }
}
