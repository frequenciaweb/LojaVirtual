using LojaVirtual.Domain.Entities;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Contracts.Repositories
{
    public interface IRepositorieCategoria : IRepositorieBase<Categoria>
    {
        List<Categoria> ObterAtivas();
    }
}
