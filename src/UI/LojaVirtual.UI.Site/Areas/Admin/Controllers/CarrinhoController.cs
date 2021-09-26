using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Contracts.Services;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 
namespace LojaVirtual.UI.Site.Areas.Admin.Controllers
{

    public class CarrinhoController : BaseController
    {
        private IServiceCarrinho ServiceCarrinho { get; set; }
        private IRepositorieCarrinho RepositorieCarrinho { get; set; }
 
        public CarrinhoController(IServiceCarrinho serviceCarrinho, IRepositorieCarrinho repositorieCarrinho)
        {
            ServiceCarrinho = serviceCarrinho;
            RepositorieCarrinho = repositorieCarrinho;
        }
 
        // GET: Carrinhos
        public IActionResult Index()
        {
            return View(RepositorieCarrinho.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Carrinho>());
            }
            
            return View(RepositorieCarrinho.Obter());
        }
 
        // GET: Carrinhos/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Carrinho Carrinho = RepositorieCarrinho.Obter((Guid)id);
            if (Carrinho == null)
            {
                return NotFound();
            }
 
            return View(Carrinho);
        }

        // GET: Carrinhos/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Carrinhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Carrinho Carrinho)
        {
            if (ModelState.IsValid)
            {
                ServiceCarrinho.Incluir(Carrinho);
                return RedirectToAction(nameof(Index));
            }
            return View(Carrinho);
        }
 
        // GET: Carrinhos/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Carrinho Carrinho = RepositorieCarrinho.Obter((Guid)id);
 
            if (Carrinho == null)
            {
                return NotFound();
            }
            return View(Carrinho);
        }
 
        // POST: Carrinhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Carrinho Carrinho)
        {
            if (id != Carrinho.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceCarrinho.Alterar(Carrinho);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(Carrinho.ID))
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
            return View(Carrinho);
        }
 
        // GET: Carrinhos/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Carrinho Carrinho = RepositorieCarrinho.Obter((Guid)id);
            if (Carrinho == null)
            {
                return NotFound();
            }
 
            return View(Carrinho);
        }
 
        // POST: Carrinhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Carrinho = RepositorieCarrinho.Obter(id);
            if (Carrinho == null)
            {
                return NotFound();
            }
            ServiceCarrinho.Excluir(Carrinho);
            return RedirectToAction(nameof(Index));
        }
 
        private bool CarrinhoExists(Guid id)
        {
            return RepositorieCarrinho.Obter(id) != null;
        }
    }
}
