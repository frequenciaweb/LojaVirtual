using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Domain.Services.Services
{

    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        public ServiceEndereco(IRepositorieEndereco repo, LojaVirtualContext context) : base(repo, context)
        {

        }
    }
}
