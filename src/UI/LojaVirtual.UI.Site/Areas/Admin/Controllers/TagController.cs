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
    public class TagController : BaseController
    {
        private IServiceTag ServiceTag { get; set; }
        private IRepositorieTag RepositorieTag { get; set; }
 
        public TagController(IServiceTag serviceTag, IRepositorieTag repositorieTag)
        {
            ServiceTag = serviceTag;
            RepositorieTag = repositorieTag;
        }
 
        // GET: Tags
        public IActionResult Index()
        {
            return View(RepositorieTag.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Tag>());
            }
            
            return View(RepositorieTag.Obter());
        }
 
        // GET: Tags/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Tag Tag = RepositorieTag.Obter((Guid)id);
            if (Tag == null)
            {
                return NotFound();
            }
 
            return View(Tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag Tag)
        {
            if (ModelState.IsValid)
            {
                ServiceTag.Incluir(Tag);
                return RedirectToAction(nameof(Index));
            }
            return View(Tag);
        }
 
        // GET: Tags/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Tag Tag = RepositorieTag.Obter((Guid)id);
 
            if (Tag == null)
            {
                return NotFound();
            }
            return View(Tag);
        }
 
        // POST: Tags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Tag Tag)
        {
            if (id != Tag.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceTag.Alterar(Tag);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(Tag.ID))
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
            return View(Tag);
        }
 
        // GET: Tags/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Tag Tag = RepositorieTag.Obter((Guid)id);
            if (Tag == null)
            {
                return NotFound();
            }
 
            return View(Tag);
        }
 
        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Tag = RepositorieTag.Obter(id);
            if (Tag == null)
            {
                return NotFound();
            }
            ServiceTag.Excluir(Tag);
            return RedirectToAction(nameof(Index));
        }
 
        private bool TagExists(Guid id)
        {
            return RepositorieTag.Obter(id) != null;
        }
    }
}
