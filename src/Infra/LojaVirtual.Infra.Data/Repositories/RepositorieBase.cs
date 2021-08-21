using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Infra.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieBase<TEntity> : IRepositorieBase<TEntity> where TEntity : class
    {
        private readonly LojaVirtualContext context;

        public RepositorieBase(LojaVirtualContext context)
        {
            this.context = context;
        }

        public virtual TEntity Alterar(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return entity;
        }

        public virtual void Excluir(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity Incluir(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual TEntity Obter(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> Obter()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}
