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

        public ActionResult CadClienteIndex(Classe_Cliente cliente)
        {
            return View(cliente);
        }

        //CADPRODUTO FOI CRIADO COM A ACTION acima
        
        public ActionResult CadCliente(Classe_Cliente cliente)
        {
            return View(cliente);
        }

        //ALTPRODUTO FOI CRIADO COM A ACTION ABAIXO


        public ActionResult AltCliente(Classe_Cliente cliente)
        {
            return View(cliente);
        }

        //DELETAR E CONSULTAR PROD FOI CRIADO COM A ACTION ABAIXO

        public ActionResult Del_Con_Cliente()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CadFuncioIndex()
        {
            var funf = new Classe_Funcionario();
            return View(funf);
        }


        public ActionResult CadFuncio(Classe_Funcionario funf) 
        {
            return View(funf);
        }

        public ActionResult AltFuncio(Classe_Funcionario funf)
        {
            return View(funf);
        }

        public ActionResult Del_Con_Funcio()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CadProdutoIndex()
        {
            var pro = new Classe_Produto();
            return View(pro);
        }

        public ActionResult CadProduto(Classe_Produto pro)
        {
            return View(pro);
        }

        public ActionResult AltProduto(Classe_Produto pro)
        {
            return View(pro);
        }

        public ActionResult Del_Con_Produto(Classe_Produto pro)
        {
            return View(pro);
        }



        public ActionResult AtividadeSucedida()
        {
            return View();
        }
        
    }
}