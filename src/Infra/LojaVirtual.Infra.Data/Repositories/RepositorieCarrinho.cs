using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieCarrinho : RepositorieBase<Carrinho>, IRepositorieCarrinho
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieCarrinho(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
