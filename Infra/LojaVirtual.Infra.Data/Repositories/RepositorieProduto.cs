using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieProduto : RepositorieBase<Produto>, IRepositorieProduto
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieProduto(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
