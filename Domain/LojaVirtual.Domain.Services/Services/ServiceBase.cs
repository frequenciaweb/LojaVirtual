using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Infra.Data.EF;

namespace LojaVirtual.Domain.Services.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositorieBase<TEntity> repositorieBase;
        private readonly LojaVirtualContext context;
        public ServiceBase(IRepositorieBase<TEntity> repositorieBase, LojaVirtualContext context)
        {
            this.context = context;
            this.repositorieBase = repositorieBase;
        }

        public virtual TEntity Alterar(TEntity entity)
        {
            entity = repositorieBase.Alterar(entity);
            Commit();
            return entity;
        }

        public virtual void Excluir(TEntity entity)
        {
            repositorieBase.Excluir(entity);
            Commit();
        }

        public virtual TEntity Incluir(TEntity entity)
        {
            entity = repositorieBase.Incluir(entity);
            Commit();
            return entity;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

    }
}
