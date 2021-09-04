using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.Infra.Data.EF;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LojaVirtual.Infra.Data.Repositories
{
    public class RepositorieProduto : RepositorieBase<Produto>, IRepositorieProduto
    {
        private LojaVirtualContext Context { get; set; }

        public RepositorieProduto(LojaVirtualContext context) : base(context)
        {
            Context = context;
        }

        public override Produto Obter(Guid id)
        {
            return Context.Produtos.Include(x => x.Fotos).FirstOrDefault(x => x.ID == id);
        }

        public List<Produto> ObterUltimosProdutos()
        {
            return Context.Produtos.OrderByDescending( x => x.Atualizado).Include(x => x.Fotos).Take(6).ToList();
        }
    }
}
