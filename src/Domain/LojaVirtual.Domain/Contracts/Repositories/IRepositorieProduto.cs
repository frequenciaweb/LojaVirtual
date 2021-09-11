using LojaVirtual.Domain.Entities;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Contracts.Repositories
{
    public interface IRepositorieProduto : IRepositorieBase<Produto>
    {
        List<Produto> ObterUltimosProdutos();
        List<Produto> ObterProdutosDestaque();
    }
}
