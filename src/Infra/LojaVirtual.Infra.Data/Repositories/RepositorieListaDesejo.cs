using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieListaDesejo : RepositorieBase<ListaDesejo>, IRepositorieListaDesejo
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieListaDesejo(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
