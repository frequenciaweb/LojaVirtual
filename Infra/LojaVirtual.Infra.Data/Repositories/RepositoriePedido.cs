using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositoriePedido : RepositorieBase<Pedido>, IRepositoriePedido
    {
        private LojaVirtualContext Context { get; set; }

        public RepositoriePedido(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
