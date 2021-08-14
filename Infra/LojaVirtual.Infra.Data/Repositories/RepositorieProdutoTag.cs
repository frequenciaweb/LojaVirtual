using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieProdutoTag : RepositorieBase<ProdutoTag>, IRepositorieProdutoTag
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieProdutoTag(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
