using LojaVirtual.Domain.Entities;

namespace LojaVirtual.Domain.Contracts.Repositories
{
    public interface IRepositorieUsuario : IRepositorieBase<Usuario>
    {
        Usuario Logar(string email, string senha);
    }
}
