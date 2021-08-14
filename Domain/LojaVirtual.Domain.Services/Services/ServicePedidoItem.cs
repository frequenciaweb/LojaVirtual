using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Domain.Services.Services
{

    public class ServicePedidoItem : ServiceBase<PedidoItem>, IServicePedidoItem
    {
        public ServicePedidoItem(IRepositoriePedidoItem repo, LojaVirtualContext context) : base(repo, context)
        {

        }
    }
}
