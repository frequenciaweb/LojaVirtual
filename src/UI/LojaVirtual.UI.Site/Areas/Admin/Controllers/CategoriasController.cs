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
    public class CategoriasController : BaseController
    {
        private IServiceCategoria ServiceCategoria { get; set; }
        private IRepositorieCategoria RepositorieCategoria { get; set; }
 
        public CategoriasController(IServiceCategoria serviceCategoria, IRepositorieCategoria repositorieCategoria)
        {
            ServiceCategoria = serviceCategoria;
            RepositorieCategoria = repositorieCategoria;
        }
 
        // GET: Categorias
        public IActionResult Index()
        {
            return View(RepositorieCategoria.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Categoria>());
            }
            
            return View(RepositorieCategoria.Obter());
        }
 
        // GET: Categorias/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Categoria Categoria = RepositorieCategoria.Obter((Guid)id);
            if (Categoria == null)
            {
                return NotFound();
            }
 
            return View(Categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria Categoria)
        {
            if (ModelState.IsValid)
            {
                ServiceCategoria.Incluir(Categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(Categoria);
        }
 
        // GET: Categorias/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Categoria Categoria = RepositorieCategoria.Obter((Guid)id);
 
            if (Categoria == null)
            {
                return NotFound();
            }
            return View(Categoria);
        }
 
        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Categoria Categoria)
        {
            if (id != Categoria.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceCategoria.Alterar(Categoria);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(Categoria.ID))
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
            return View(Categoria);
        }
 
        // GET: Categorias/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Categoria Categoria = RepositorieCategoria.Obter((Guid)id);
            if (Categoria == null)
            {
                return NotFound();
            }
 
            return View(Categoria);
        }
 
        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Categoria = RepositorieCategoria.Obter(id);
            if (Categoria == null)
            {
                return NotFound();
            }
            ServiceCategoria.Excluir(Categoria);
            return RedirectToAction(nameof(Index));
        }
 
        private bool CategoriaExists(Guid id)
        {
            return RepositorieCategoria.Obter(id) != null;
        }
    }
}
