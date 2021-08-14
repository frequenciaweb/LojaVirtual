using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieCategoria : RepositorieBase<Categoria>, IRepositorieCategoria
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieCategoria(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
