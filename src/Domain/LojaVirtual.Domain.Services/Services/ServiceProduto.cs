using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;
using System;

namespace LojaVirtual.Domain.Services.Services
{

    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositorieProduto repositorieProduto;
        private readonly IRepositorieFoto repositorieFoto;

        public ServiceProduto(IRepositorieProduto repo, IRepositorieFoto repositorieFoto, LojaVirtualContext context) : base(repo, context)
        {
            repositorieProduto = repo;
            this.repositorieFoto = repositorieFoto;
        }

        public void IncluirImagem(Foto foto)
        {
            repositorieFoto.Incluir(foto);
            Commit();
        }

        public void RemoverImagem(Foto foto)
        {
            repositorieFoto.Excluir(foto);
            Commit();
        }
    }
}
