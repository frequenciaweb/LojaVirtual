using LojaVirtual.Domain.Enums;
using System;

namespace LojaVirtual.Domain.Entities
{
    public class Usuario
    {
        public Guid ID { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public DateTime Cadastro { get; set; }

        public EnumPerfil Perfil { get; set; }
    }
}
