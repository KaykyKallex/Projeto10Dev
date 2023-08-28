using P10.Dados;
using P10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P10.Controllers
{
    public class HomeController : Controller
    {
        AcLogin ac = new AcLogin();
        public ActionResult Index()
        {
            ViewData["login"] = TempData["MSG"];
            return View();
        }
        public ActionResult Logar()
        {
            
            return View();
        }
        public ActionResult Verificar(login login)
        {
            ac.TestarUsuario(login);
            if (login.Usuario != null && login.Senha != null)
            {
                Session["usuario"] = login.Usuario.ToString();
                Session["senha"] = login.Senha.ToString();
                TempData["MSG"] = "Usuário Logado";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Logar");
            }
        }
    }
}