using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Contracts.Repositories
{
    public interface IRepositorieBase<TEntity> where TEntity : class
    {
        TEntity Incluir(TEntity entity);
        TEntity Alterar(TEntity entity);
        void Excluir(TEntity entity);
        TEntity Obter(Guid id);
        List<TEntity> Obter();
    }
}
