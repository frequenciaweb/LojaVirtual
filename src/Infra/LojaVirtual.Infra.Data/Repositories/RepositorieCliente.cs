using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieCliente : RepositorieBase<Cliente>, IRepositorieCliente
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieCliente(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
