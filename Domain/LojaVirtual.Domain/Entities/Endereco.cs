using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Entities
{
    public class Endereco
    {
        public Guid ID { get; set; }

        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }

        //public List<Endereco> ClientesEntrega { get; set; } = new List<Endereco>();
        //public List<Endereco> Clientes { get; set; } = new List<Endereco>();
    }
}
