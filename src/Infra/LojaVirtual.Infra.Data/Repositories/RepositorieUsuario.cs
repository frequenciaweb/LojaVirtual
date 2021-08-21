using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieUsuario : RepositorieBase<Usuario>, IRepositorieUsuario
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieUsuario(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
