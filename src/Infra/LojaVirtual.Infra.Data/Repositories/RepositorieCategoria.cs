using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieCategoria : RepositorieBase<Categoria>, IRepositorieCategoria
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieCategoria(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }

        public List<Categoria> ObterAtivas()
        {
            return Context.Categorias.Where(x => x.Ativa).ToList();
        }
    }
}
