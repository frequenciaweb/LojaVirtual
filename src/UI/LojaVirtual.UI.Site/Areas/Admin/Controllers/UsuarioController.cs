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
    public class UsuarioController : Controller
    {
        private IServiceUsuario ServiceUsuario { get; set; }
        private IRepositorieUsuario RepositorieUsuario { get; set; }
 
        public UsuarioController(IServiceUsuario serviceUsuario, IRepositorieUsuario repositorieUsuario)
        {
            ServiceUsuario = serviceUsuario;
            RepositorieUsuario = repositorieUsuario;
        }
 
        // GET: Usuarios
        public IActionResult Index()
        {
            return View(RepositorieUsuario.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Usuario>());
            }
            
            return View(RepositorieUsuario.Obter());
        }
 
        // GET: Usuarios/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Usuario Usuario = RepositorieUsuario.Obter((Guid)id);
            if (Usuario == null)
            {
                return NotFound();
            }
 
            return View(Usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                ServiceUsuario.Incluir(Usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(Usuario);
        }
 
        // GET: Usuarios/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Usuario Usuario = RepositorieUsuario.Obter((Guid)id);
 
            if (Usuario == null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
 
        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Usuario Usuario)
        {
            if (id != Usuario.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceUsuario.Alterar(Usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(Usuario.ID))
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
            return View(Usuario);
        }
 
        // GET: Usuarios/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Usuario Usuario = RepositorieUsuario.Obter((Guid)id);
            if (Usuario == null)
            {
                return NotFound();
            }
 
            return View(Usuario);
        }
 
        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Usuario = RepositorieUsuario.Obter(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            ServiceUsuario.Excluir(Usuario);
            return RedirectToAction(nameof(Index));
        }
 
        private bool UsuarioExists(Guid id)
        {
            return RepositorieUsuario.Obter(id) != null;
        }
    }
}
