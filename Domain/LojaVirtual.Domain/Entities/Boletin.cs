using System;

namespace LojaVirtual.Domain.Entities
{
    public class Boletin
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public DateTime Cadastro { get; set; }

        public Guid? ClienteID { get; set; }
        public Cliente Cliente { get; set; }
    }
}