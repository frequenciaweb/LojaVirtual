using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Categoria
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public List<CupomCategoria> CupomCategorias { get; set; } 
    }
}
