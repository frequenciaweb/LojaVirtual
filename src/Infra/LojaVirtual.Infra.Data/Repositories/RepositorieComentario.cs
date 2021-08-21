using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieComentario : RepositorieBase<Comentario>, IRepositorieComentario
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieComentario(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }
    }
}
