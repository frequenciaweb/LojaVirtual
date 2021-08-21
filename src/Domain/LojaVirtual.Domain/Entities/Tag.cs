using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Tag
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public List<ProdutoTag> ProdutoTags { get; set; } = new List<ProdutoTag>();
    }
}
