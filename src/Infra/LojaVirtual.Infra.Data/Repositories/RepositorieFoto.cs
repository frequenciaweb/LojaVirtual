using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieFoto : RepositorieBase<Foto>, IRepositorieFoto
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieFoto(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
