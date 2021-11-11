using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAME_WAVE___SISTEMA_ASP_NET.Models;
using GAME_WAVE___SISTEMA_ASP_NET.Repositorio;
namespace GAME_WAVE___SISTEMA_ASP_NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        Acoes ac = new Acoes();
        [HttpPost]

        public ActionResult CadProduto()
        {
            var cliente = new Classe_Cliente();
            return View(cliente);
        }

        //CADPRODUTO FOI CRIADO COM A ACTION ABAIXO
        
        public ActionResult CadProduto(Classe_Cliente cliente)
        {
            return View(cliente);
        }

        //ALTPRODUTO FOI CRIADO COM A ACTION ABAIXO


        public ActionResult AltProduto(Classe_Cliente cliente)
        {
            return View(cliente);
        }

        //DELETAR E CONSULTAR PROD FOI CRIADO COM A ACTION ABAIXO

        public ActionResult Del_Con_Produto()
        {
            return View();
        }

        public ActionResult AtividadeSucedida()
        {
            return View();
        }
        
    }
}