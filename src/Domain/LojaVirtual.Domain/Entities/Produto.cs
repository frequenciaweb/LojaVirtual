using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Produto
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public decimal Valor { get; set; }
        
        public string Marca { get; set; }

        public Guid CategoriaID { get; set; }
        public Categoria Categoria {get; set;}

        public int Estoque { get; set; }

        public List<ProdutoTag> Tags { get; set; } = new List<ProdutoTag>();
        public List<Carrinho> ItensCarrinho { get; set; } = new List<Carrinho>();
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
        public List<Desconto> Descontos { get; set; } = new List<Desconto>();
        public List<Foto> Fotos { get; set; } = new List<Foto>();
        public List<ListaDesejo> Desejos { get; set; } = new List<ListaDesejo>();
        public List<PedidoItem> PedidoItems { get; set; } = new List<PedidoItem>();

    }
}
