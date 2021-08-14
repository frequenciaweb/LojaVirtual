namespace LojaVirtual.Domain.Contracts.Services
{

    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Incluir(TEntity entity);
        TEntity Alterar(TEntity entity);
        void Excluir(TEntity entity);
        void Commit();
    }

}
