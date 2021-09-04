using LojaVirtual.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Infra.Data.EF
{
    public static class SEED
    {
        public static  void Populate(LojaVirtualContext context)
        {
            Categoria categoria = new Categoria();

            if (context.Categorias.Count() == 0)
            {
                categoria = new Categoria
                {
                    Ativa = true,
                    ID = Guid.NewGuid(),
                    Nome = "PRODUTOS SMARTS"
                };
                context.Categorias.Add(categoria);
            }



            if (context.Produtos.Count() == 0)
            {



                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Samsung Galaxy s5- 2015",
                    Nome = "Samsung Galaxy s5- 2015",
                    Marca = "SAMSUNG",
                    Valor = 700,
                    Fotos = new List<Foto> { new Foto { Nome = "produto1.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });

                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Nokia Lumia 1320",
                    Nome = "Nokia Lumia 1320",
                    Marca = "Nokia",
                    Valor = 899,
                    Fotos = new List<Foto> { new Foto { Nome = "produto2.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });

                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Lg Leon 2015",
                    Nome = "Lg Leon 2015",
                    Marca = "LG",
                    Valor = 400,
                    Fotos = new List<Foto> { new Foto { Nome = "produto3.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });

                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Sony Microsoft",
                    Nome = "Sony Microsoft",
                    Marca = "MICROSOFT",
                    Valor = 200,
                    Fotos = new List<Foto> { new Foto { Nome = "produto4.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });

                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Iphone 6",
                    Nome = "Iphone 6",
                    Marca = "Apple",
                    Valor = 1200,
                    Fotos = new List<Foto> { new Foto { Nome = "produto5.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });

                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Samung Gallaxy note 4",
                    Nome = "Samung Gallaxy note 4",
                    Marca = "SAMSUNG",
                    Valor = 400,
                    Fotos = new List<Foto> { new Foto { Nome = "produto6.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });

                context.Produtos.Add(new Produto
                {
                    CategoriaID = categoria.ID,
                    Descricao = "Iphone 7",
                    Nome = "Iphone 7",
                    Marca = "Apple",
                    Valor = 500,
                    Fotos = new List<Foto> { new Foto { Nome = "produto7.jpg", Caminho = "imagens", Tipo = "CAPA" } }
                });
            }
            context.SaveChanges();
        }
    }
}
