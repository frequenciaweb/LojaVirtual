using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieTag : RepositorieBase<Tag>, IRepositorieTag
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieTag(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
