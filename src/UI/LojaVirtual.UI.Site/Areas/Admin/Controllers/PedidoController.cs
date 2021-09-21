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
    public class PedidoController : Controller
    {
        private IServicePedido ServicePedido { get; set; }
        private IRepositoriePedido RepositoriePedido { get; set; }
 
        public PedidoController(IServicePedido servicePedido, IRepositoriePedido repositoriePedido)
        {
            ServicePedido = servicePedido;
            RepositoriePedido = repositoriePedido;
        }
 
        // GET: Pedidos
        public IActionResult Index()
        {
            return View(RepositoriePedido.Obter());
        }
 
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Pedido>());
            }
            
            return View(RepositoriePedido.Obter());
        }
 
        // GET: Pedidos/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Pedido Pedido = RepositoriePedido.Obter((Guid)id);
            if (Pedido == null)
            {
                return NotFound();
            }
 
            return View(Pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido Pedido)
        {
            if (ModelState.IsValid)
            {
                ServicePedido.Incluir(Pedido);
                return RedirectToAction(nameof(Index));
            }
            return View(Pedido);
        }
 
        // GET: Pedidos/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Pedido Pedido = RepositoriePedido.Obter((Guid)id);
 
            if (Pedido == null)
            {
                return NotFound();
            }
            return View(Pedido);
        }
 
        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Pedido Pedido)
        {
            if (id != Pedido.ID)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    ServicePedido.Alterar(Pedido);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(Pedido.ID))
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
            return View(Pedido);
        }
 
        // GET: Pedidos/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 
            Pedido Pedido = RepositoriePedido.Obter((Guid)id);
            if (Pedido == null)
            {
                return NotFound();
            }
 
            return View(Pedido);
        }
 
        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Pedido = RepositoriePedido.Obter(id);
            if (Pedido == null)
            {
                return NotFound();
            }
            ServicePedido.Excluir(Pedido);
            return RedirectToAction(nameof(Index));
        }
 
        private bool PedidoExists(Guid id)
        {
            return RepositoriePedido.Obter(id) != null;
        }
    }
}
