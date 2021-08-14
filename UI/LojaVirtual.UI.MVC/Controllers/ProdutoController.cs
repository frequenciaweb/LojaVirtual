using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
namespace LojaVirtual.UI.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private IServiceProduto ServiceProduto { get; set; }
        private IRepositorieProduto RepositorieProduto { get; set; }
 
        public ProdutoController(IServiceProduto serviceProduto, IRepositorieProduto repositorieProduto)
        {
            ServiceProduto = serviceProduto;
            RepositorieProduto = repositorieProduto;
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
            return View(Produto);
        }
 
        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Produto Produto)
        {
            if (id != Produto.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
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
