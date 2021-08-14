using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieDesconto : RepositorieBase<Desconto>, IRepositorieDesconto
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieDesconto(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
