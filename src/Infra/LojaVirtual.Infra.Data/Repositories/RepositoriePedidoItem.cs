using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositoriePedidoItem : RepositorieBase<PedidoItem>, IRepositoriePedidoItem
    {
        private LojaVirtualContext Context { get; set; }

        public RepositoriePedidoItem(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
