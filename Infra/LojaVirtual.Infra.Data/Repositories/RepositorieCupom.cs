using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieCupom : RepositorieBase<Cupom>, IRepositorieCupom
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieCupom(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
