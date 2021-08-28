using LojaVirtual.Domain.Entities;
using System;

namespace LojaVirtual.Domain.Contracts.Services
{
    public interface IServiceProduto : IServiceBase<Produto>
    {
        void IncluirImagem(Foto foto);
        void RemoverImagem(Foto foto);
    }
}
