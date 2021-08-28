using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LojaVirtual.UI.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private IServiceProduto ServiceProduto { get; set; }
        private IRepositorieProduto RepositorieProduto { get; set; }
        private IRepositorieCategoria RepositorieCategoria { get; set; }
        private IRepositorieFoto RepositorieFoto { get; set; }

        public ProdutoController(IServiceProduto serviceProduto, IRepositorieProduto repositorieProduto, IRepositorieCategoria repositorieCategoria, IRepositorieFoto repositorieFoto)
        {
            ServiceProduto = serviceProduto;
            RepositorieProduto = repositorieProduto;
            RepositorieCategoria = repositorieCategoria;
            RepositorieFoto = repositorieFoto;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            return View(RepositorieProduto.Obter());
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Produto>());
            }

            return View(RepositorieProduto.Obter());
        }

        // GET: Produtos/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Produto Produto = RepositorieProduto.Obter((Guid)id);            

            if (Produto == null)
            {
                return NotFound();
            }

            return View(Produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewBag.ListaCategoria = RepositorieCategoria.ObterAtivas().Select(
                             x => new SelectListItem
                             {
                                 Text = x.Nome,
                                 Value = x.ID.ToString()
                             })
                             .ToList();

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto Produto)
        {
            if (ModelState.IsValid)
            {
                ServiceProduto.Incluir(Produto);
                return RedirectToAction(nameof(Index));
            }
            return View(Produto);
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto Produto = RepositorieProduto.Obter((Guid)id);

            if (Produto == null)
            {
                return NotFound();
            }

            ViewBag.ListaCategoria = RepositorieCategoria.ObterAtivas().Select(
                             x => new SelectListItem
                             {
                                 Text = x.Nome,
                                 Value = x.ID.ToString()
                             })
                             .ToList();

            return View(Produto);
        }
                
        public IActionResult RemoverImagem(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Foto foto = RepositorieFoto.Obter((Guid)id);

            if (foto == null)
            {
                return NotFound();
            }

            ServiceProduto.RemoverImagem(foto);

            return RedirectToAction(nameof(Edit), new { id = foto.ProdutoID });
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Produto Produto, IFormCollection form)
        {
            if (id != Produto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (form.Files.Count > 0)
                    {
                        var file = form.Files[0];
                        string nome = DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".jpg";
                        string caminho = System.Environment.CurrentDirectory + @"\wwwroot\imagens\";
                        string tipo = form["tipo"];

                        if (!Directory.Exists(caminho))
                        {
                            Directory.CreateDirectory(caminho);
                        }

                        using (FileStream saida = new FileStream(caminho + nome, FileMode.Create))
                        {
                            file.OpenReadStream().CopyTo(saida);
                        }
                        ServiceProduto.IncluirImagem(new Foto { Tipo = tipo, Caminho = caminho, Nome = nome, ProdutoID = Produto.ID });
                    }

                    ServiceProduto.Alterar(Produto);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(Produto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Produto);
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto Produto = RepositorieProduto.Obter((Guid)id);
            if (Produto == null)
            {
                return NotFound();
            }

            return View(Produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Produto = RepositorieProduto.Obter(id);
            if (Produto == null)
            {
                return NotFound();
            }
            ServiceProduto.Excluir(Produto);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
            return RepositorieProduto.Obter(id) != null;
        }
    }
}
