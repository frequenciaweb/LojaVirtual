using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Cupom
    {
        public Guid ID { get; set; }
        public string Codigo { get; set; }
        public DateTime Validade { get; set; }
        public int Percentual { get; set; }

        public List<CupomCategoria> Categorias { get; set; } = new List<CupomCategoria>();

        public List<Pedido> Pedidos { get; set; }
    }
}
