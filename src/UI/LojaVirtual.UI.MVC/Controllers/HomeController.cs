using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace LojaVirtual.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorieProduto _repositorieProdutos;

        public HomeController(ILogger<HomeController> logger, IRepositorieProduto repositorieProdutos)
        {
            _logger = logger;
            _repositorieProdutos = repositorieProdutos;
        }

        public IActionResult Index()
        {

                List<VMProdutosDestaque> produtosDestaque = _repositorieProdutos.ObterProdutosDestaque()
                .Select(produto => new VMProdutosDestaque
                {
                    ID = produto.ID,
                    Imagem = produto.Fotos?.FirstOrDefault(x => x.Tipo == "BANNER")?.Nome,
                    Titulo = produto.Nome
                }).ToList();

                List<VMUltimosProdutos> ultimosProdutos = _repositorieProdutos?.ObterUltimosProdutos()?
                .Select(produto => new VMUltimosProdutos 
                { 
                    ID = produto.ID,
                    Titulo = produto.Nome,
                    ValorAtual = produto.Valor,
                    ValorAntigo = produto.Valor,
                    Imagem = produto.Fotos?.FirstOrDefault(x => x.Tipo == "CAPA")?.Nome
                })
                .ToList();

            ViewBag.UltimosProdutos = ultimosProdutos;
            ViewBag.ProdutosDestaque = produtosDestaque;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
