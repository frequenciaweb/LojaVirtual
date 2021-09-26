using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;
using System.Linq;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieUsuario : RepositorieBase<Usuario>, IRepositorieUsuario
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieUsuario(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }

        public Usuario Logar(string email, string senha)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
