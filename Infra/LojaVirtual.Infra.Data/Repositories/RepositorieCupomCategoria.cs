using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieCupomCategoria : RepositorieBase<CupomCategoria>, IRepositorieCupomCategoria
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieCupomCategoria(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
