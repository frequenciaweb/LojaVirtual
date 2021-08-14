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
    public class BoletinController : Controller
    {
        private IServiceBoletin ServiceBoletin { get; set; }
        private IRepositorieBoletin RepositorieBoletin { get; set; }
 
        public BoletinController(IServiceBoletin serviceBoletin, IRepositorieBoletin repositorieBoletin)
        {
            ServiceBoletin = serviceBoletin;
            RepositorieBoletin = repositorieBoletin;
        }
 
        // GET: Boletins
        public IActionResult Index()
        {
            return View(RepositorieBoletin.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Boletin>());
            }
            
            return View(RepositorieBoletin.Obter());
        }
 
        // GET: Boletins/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Boletin Boletin = RepositorieBoletin.Obter((Guid)id);
            if (Boletin == null)
            {
                return NotFound();
            }
 
            return View(Boletin);
        }

        // GET: Boletins/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Boletins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Boletin Boletin)
        {
            if (ModelState.IsValid)
            {
                ServiceBoletin.Incluir(Boletin);
                return RedirectToAction(nameof(Index));
            }
            return View(Boletin);
        }
 
        // GET: Boletins/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Boletin Boletin = RepositorieBoletin.Obter((Guid)id);
 
            if (Boletin == null)
            {
                return NotFound();
            }
            return View(Boletin);
        }
 
        // POST: Boletins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Boletin Boletin)
        {
            if (id != Boletin.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceBoletin.Alterar(Boletin);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletinExists(Boletin.ID))
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
            return View(Boletin);
        }
 
        // GET: Boletins/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Boletin Boletin = RepositorieBoletin.Obter((Guid)id);
            if (Boletin == null)
            {
                return NotFound();
            }
 
            return View(Boletin);
        }
 
        // POST: Boletins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Boletin = RepositorieBoletin.Obter(id);
            if (Boletin == null)
            {
                return NotFound();
            }
            ServiceBoletin.Excluir(Boletin);
            return RedirectToAction(nameof(Index));
        }
 
        private bool BoletinExists(Guid id)
        {
            return RepositorieBoletin.Obter(id) != null;
        }
    }
}
