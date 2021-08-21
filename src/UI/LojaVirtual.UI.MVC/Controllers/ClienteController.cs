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
    public class ClienteController : Controller
    {
        private IServiceCliente ServiceCliente { get; set; }
        private IRepositorieCliente RepositorieCliente { get; set; }
 
        public ClienteController(IServiceCliente serviceCliente, IRepositorieCliente repositorieCliente)
        {
            ServiceCliente = serviceCliente;
            RepositorieCliente = repositorieCliente;
        }
 
        // GET: Clientes
        public IActionResult Index()
        {
            return View(RepositorieCliente.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Cliente>());
            }
            
            return View(RepositorieCliente.Obter());
        }
 
        // GET: Clientes/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Cliente Cliente = RepositorieCliente.Obter((Guid)id);
            if (Cliente == null)
            {
                return NotFound();
            }
 
            return View(Cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                ServiceCliente.Incluir(Cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(Cliente);
        }
 
        // GET: Clientes/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Cliente Cliente = RepositorieCliente.Obter((Guid)id);
 
            if (Cliente == null)
            {
                return NotFound();
            }
            return View(Cliente);
        }
 
        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Cliente Cliente)
        {
            if (id != Cliente.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServiceCliente.Alterar(Cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(Cliente.ID))
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
            return View(Cliente);
        }
 
        // GET: Clientes/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Cliente Cliente = RepositorieCliente.Obter((Guid)id);
            if (Cliente == null)
            {
                return NotFound();
            }
 
            return View(Cliente);
        }
 
        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Cliente = RepositorieCliente.Obter(id);
            if (Cliente == null)
            {
                return NotFound();
            }
            ServiceCliente.Excluir(Cliente);
            return RedirectToAction(nameof(Index));
        }
 
        private bool ClienteExists(Guid id)
        {
            return RepositorieCliente.Obter(id) != null;
        }
    }
}
