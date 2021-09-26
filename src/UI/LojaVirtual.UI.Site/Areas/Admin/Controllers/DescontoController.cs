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
    public class DescontoController : BaseController
    {
        private IServiceDesconto ServiceDesconto { get; set; }
        private IRepositorieDesconto RepositorieDesconto { get; set; }
 
        public DescontoController(IServiceDesconto serviceDesconto, IRepositorieDesconto repositorieDesconto)
        {
            ServiceDesconto = serviceDesconto;
            RepositorieDesconto = repositorieDesconto;
        }
 
        // GET: Descontos
        public IActionResult Index()
        {
            return View(RepositorieDesconto.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Desconto>());
            }
            
            return View(RepositorieDesconto.Obter());
        }
 
        // GET: Descontos/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Desconto Desconto = RepositorieDesconto.Obter((Guid)id);
            if (Desconto == null)
            {
                return NotFound();
            }
 
            return View(Desconto);
        }

        // GET: Descontos/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Descontos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Desconto Desconto)
        {
            if (ModelState.IsValid)
            {
                ServiceDesconto.Incluir(Desconto);
                return RedirectToAction(nameof(Index));
            }
            return View(Desconto);
        }
 
        // GET: Descontos/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Desconto Desconto = RepositorieDesconto.Obter((Guid)id);
 
            if (Desconto == null)
            {
                return NotFound();
            }
            return View(Desconto);
        }
 
        // POST: Descontos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Desconto Desconto)
        {
            if (id != Desconto.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceDesconto.Alterar(Desconto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescontoExists(Desconto.ID))
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
            return View(Desconto);
        }
 
        // GET: Descontos/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Desconto Desconto = RepositorieDesconto.Obter((Guid)id);
            if (Desconto == null)
            {
                return NotFound();
            }
 
            return View(Desconto);
        }
 
        // POST: Descontos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Desconto = RepositorieDesconto.Obter(id);
            if (Desconto == null)
            {
                return NotFound();
            }
            ServiceDesconto.Excluir(Desconto);
            return RedirectToAction(nameof(Index));
        }
 
        private bool DescontoExists(Guid id)
        {
            return RepositorieDesconto.Obter(id) != null;
        }
    }
}
