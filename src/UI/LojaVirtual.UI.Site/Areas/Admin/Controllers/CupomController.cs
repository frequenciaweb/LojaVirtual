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
    public class CupomController : BaseController
    {
        private IServiceCupom ServiceCupom { get; set; }
        private IRepositorieCupom RepositorieCupom { get; set; }
 
        public CupomController(IServiceCupom serviceCupom, IRepositorieCupom repositorieCupom)
        {
            ServiceCupom = serviceCupom;
            RepositorieCupom = repositorieCupom;
        }
 
        // GET: Cupoms
        public IActionResult Index()
        {
            return View(RepositorieCupom.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Cupom>());
            }
            
            return View(RepositorieCupom.Obter());
        }
 
        // GET: Cupoms/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Cupom Cupom = RepositorieCupom.Obter((Guid)id);
            if (Cupom == null)
            {
                return NotFound();
            }
 
            return View(Cupom);
        }

        // GET: Cupoms/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Cupoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cupom Cupom)
        {
            if (ModelState.IsValid)
            {
                ServiceCupom.Incluir(Cupom);
                return RedirectToAction(nameof(Index));
            }
            return View(Cupom);
        }
 
        // GET: Cupoms/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Cupom Cupom = RepositorieCupom.Obter((Guid)id);
 
            if (Cupom == null)
            {
                return NotFound();
            }
            return View(Cupom);
        }
 
        // POST: Cupoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Cupom Cupom)
        {
            if (id != Cupom.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceCupom.Alterar(Cupom);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CupomExists(Cupom.ID))
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
            return View(Cupom);
        }
 
        // GET: Cupoms/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Cupom Cupom = RepositorieCupom.Obter((Guid)id);
            if (Cupom == null)
            {
                return NotFound();
            }
 
            return View(Cupom);
        }
 
        // POST: Cupoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Cupom = RepositorieCupom.Obter(id);
            if (Cupom == null)
            {
                return NotFound();
            }
            ServiceCupom.Excluir(Cupom);
            return RedirectToAction(nameof(Index));
        }
 
        private bool CupomExists(Guid id)
        {
            return RepositorieCupom.Obter(id) != null;
        }
    }
}
