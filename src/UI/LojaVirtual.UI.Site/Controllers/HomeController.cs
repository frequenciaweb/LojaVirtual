using LojaVirtual.Domain.Contracts.Repositories;
using LojaVirtual.Domain.Entities;
using LojaVirtual.UI.Site.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LojaVirtual.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorieUsuario RepositorieUsuario;

        public HomeController(ILogger<HomeController> logger, IRepositorieUsuario repositorieUsuario)
        {
            _logger = logger;
            RepositorieUsuario = repositorieUsuario;
        }

        public IActionResult Index()
        {
            return Redirect("/loja");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(MVLogin login)
        {

            if (ModelState.IsValid)
            {

                Usuario usuario = RepositorieUsuario.Logar(login.Email, login.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError("", "Usuário ou senha inválidos");
                    return View();
                }

                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
                userClaims.Add(new Claim(ClaimTypes.Email, usuario.Email));
                userClaims.Add(new Claim("ID", usuario.ID.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Role, usuario.Perfil.ToString()));

                var minhaIdentidade = new ClaimsIdentity(userClaims, "UserLoginCookie");
                var principal = new ClaimsPrincipal(new[] { minhaIdentidade });

                HttpContext.SignInAsync(principal);

                if (usuario.Perfil == Domain.Enums.EnumPerfil.Administrador)
                {
                    return Redirect("/admin");
                }

                return Redirect("/loja");
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/loja");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Register()
        {
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
    }
}
