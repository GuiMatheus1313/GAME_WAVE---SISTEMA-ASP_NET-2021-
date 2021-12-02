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

        public ActionResult CadClienteIndex(Classe_Cliente clie)
        {
            return View(clie);
        }

        //CADPRODUTO FOI CRIADO COM A ACTION acima
        [HttpPost]
        public ActionResult CadCliente(Classe_Cliente cliente)
        {
            ac.CadastrarCliente(cliente);
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
            var ExibiCliente = new Acoes();
            var TodosClien = ExibiCliente.ListarCli();
            return View(TodosClien);
        }


        public ActionResult CadFuncioIndex(Classe_Funcionario funf)
        {
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

        public ActionResult CadProdutoIndex(Classe_Produto pro)
        {
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
