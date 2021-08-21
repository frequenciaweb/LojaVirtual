using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieEndereco : RepositorieBase<Endereco>, IRepositorieEndereco
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieEndereco(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
