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
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult CadCupomIndex(Classe_Cupom cupom)
        {
            return View(cupom);
        }

        public ActionResult CadCupom(Classe_Cupom cupom)
        {
            ac.CadastroCupom(cupom);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult CadTesteIndex (Classe_Teste teste)
        {
            return View(teste);
        }

        public ActionResult CadTeste (Classe_Teste teste)
        {
            ac.CadastroTeste(teste);
            return RedirectToAction("AtividadeSucedida"); 
        }

        public ActionResult CadServicoIndex (Classe_Servico servico)
        {
            return View(servico);
        }

        public ActionResult CadServico (Classe_Servico servico)
        {
            ac.CadastroServico(servico);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult CadVendaIndex (Classe_Venda venda)
        {
            return View(venda);
        }

        public ActionResult CadVenda (Classe_Venda venda)
        {
            ac.CadastroVenda(venda);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult CadDeliveryIndex (Classe_Delivery delivery)
        {
            return View(delivery);
        }

        public ActionResult CadDelivery (Classe_Delivery delivery)
        {
            ac.CadastroDelivery(delivery);
            return RedirectToAction("AtividadeSucedida");
        }

        //ALTPRODUTO FOI CRIADO COM A ACTION ABAIXO

        [HttpGet]
        public ActionResult AltCliente(string cpf)
        {
            var Cpfcli = ac.ListarCliCpf(cpf);
            if (Cpfcli == null)
            {
                return HttpNotFound();
            }
            
            return View(cpf);
        }

        [HttpPost]
        public ActionResult AltCliente(Classe_Cliente cpf)
        {
            ac.AltCliente(cpf);
            return RedirectToAction("Del_Con_Cliente");
        }

        public ActionResult DelCliente(string cpf)
        {
            ac.DelCliente(cpf);
            return RedirectToAction("Del_Con_Cliente");
        }
        /*
        public ActionResult DelCupom(string cupom_cod)
        {
            ac.DelCupom(cupom_cod);
            return RedirectToAction("Del_Con_Cupom");
        }

        public ActionResult DelTeste (int agen_Cod)
        {
            ac.DelTeste(agen_Cod);
            return RedirectToAction("Del_Con_Teste");
        }

        public ActionResult DelServico (int cod_Serv)
        {
            ac.DelServico(cod_Serv);
            return RedirectToAction("Del_Con_Servico");
        }

        public ActionResult DelVenda (int ven_Cod)
        {
            ac.
            return RedirectToAction("");
        }

        public ActionResult DelDelivery (int deli_Cod)
        {
            ac.DelDelivery(deli_Cod);
            return RedirectToAction("Del_Con_Delivery");
        }
        */

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

        [HttpPost]
        public ActionResult CadFuncio(Classe_Funcionario funf) 
        {
            ac.CadastrarFuncio(funf);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult AltFuncio(Classe_Funcionario funf)
        {
            return View(funf);
        }

        public ActionResult Del_Con_Funcio()
        {
            var ExibiFuncio = new Acoes();
            var TodosFuncio = ExibiFuncio.ListarFuncio();
            return View(TodosFuncio);
        }

        public ActionResult CadProdutoIndex(Classe_Produto pro)
        {
            return View(pro);
        }

        [HttpPost]
        public ActionResult CadProduto(Classe_Produto pro)
        {
            ac.CadastroProduto(pro);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult AltProduto(Classe_Produto pro)
        {
            return View(pro);
        }

        public ActionResult Del_Con_Produto(Classe_Produto pro)
        {
            var ExibirProd = new Acoes();
            var TodosProd = ExibirProd.ListarProd();
            return View(TodosProd);
        }

        public ActionResult Del_Con_Cupom (Classe_Cupom cupom)
        {
            var Exibircup = new Acoes();
            var Todoscup = Exibircup.ListarCup();
            return View(Todoscup);
        }

        /*
        public ActionResult Del_Con_Teste (Classe_Teste teste)
        {
            var Exibirtes = new Acoes();
            var Todostes = Exibirtes.
            return View(Todostes);
        }

        public ActionResult Del_Con_Servico (Classe_Servico serv)
        {
            var Exibirser = new Acoes();
            var Todosserv = Exibirser.
            return View(Todosserv);
        }

        public ActionResult Del_Con_Venda (Classe_Venda vend)
        {
            var Exibirven = new Acoes();
            var Todosven = Exibirven.
            return View(Todosven);
        }

        public ActionResult Del_Con_Delivery (Classe_Delivery deliv)
        {
            var Exibirdeli = new Acoes();
            var Todosdeli = Exibirdeli.
            return View(Todosdeli);
        }

        */
        public ActionResult AtividadeSucedida()
        {
            return View();
        }
        
    }
}
