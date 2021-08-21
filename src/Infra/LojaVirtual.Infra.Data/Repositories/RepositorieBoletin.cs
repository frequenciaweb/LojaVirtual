using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieBoletin : RepositorieBase<Boletin>, IRepositorieBoletin
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieBoletin(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
