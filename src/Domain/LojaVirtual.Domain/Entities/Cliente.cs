using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Cliente
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }

        public Guid EnderecoEntregaID { get; set; }
        public Endereco EnderecoEntrega { get; set; }

        public Guid EnderecoID { get; set; }
        public Endereco Endereco { get; set; }
     
        public Guid UsuarioID { get; set; }
        public Usuario Usuario { get; set; }

        public List<Boletin> Boletins { get; set; } = new List<Boletin>();
        public List<Carrinho> ItemsCarrinho { get; set; } = new List<Carrinho>();
        public List<ListaDesejo> Desejos { get; set; } = new List<ListaDesejo>();
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

    }
}
