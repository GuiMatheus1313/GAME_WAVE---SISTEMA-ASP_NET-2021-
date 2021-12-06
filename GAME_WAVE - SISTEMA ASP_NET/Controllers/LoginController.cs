using GAME_WAVE___SISTEMA_ASP_NET.Models;
using GAME_WAVE___SISTEMA_ASP_NET.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GAME_WAVE___SISTEMA_ASP_NET.Controllers
{
    public class LoginController : Controller
    {
        Acoes ac = new Acoes();
        public ActionResult LoginIndex()
        {
            return View();
        }

        public ActionResult verificafuncio(Classe_Funcionario fun)
        {
            ac.VerificacaoFuncionario(fun);

            if (fun.Func_cpf != null && fun.Func_senha != null)
            {
                FormsAuthentication.SetAuthCookie(fun.Func_cpf, false);
                Session["UsuarioLogado"] = fun.Func_cpf.ToString();
                Session["SenhaLogado"] = fun.Func_senha.ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginIndex", "Login");
            }
        }

        public ActionResult Sair()
        {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("LoginIndex", "Login");
        }
    }
}