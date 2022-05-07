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
        //INDEX PRINCIPAL
        public ActionResult Index()
        {
            return View();
        }
        Acoes ac = new Acoes();

        //TODAS AS CONTROLLERS PARA O CADASTRO DAS CLASSES UTILIZADOS ATÉ AGORA

        public ActionResult CadClienteIndex(Classe_Cliente clie)
        {
            return View(clie);
        }

        [HttpPost]
        public ActionResult CadCliente(Classe_Cliente cliente)
        {
            //COM A PARTE DA INDEX, É FEITO A TRANSFERÊNCIA DOS CAMPOS DESTAS PARA A O MÉTODO DE CADASTRO DA AÇÕES POR MEIO DO HTTPOST
            ac.CadastrarCliente(cliente);
            return RedirectToAction("AtividadeSucedida");
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

        [HttpPost]
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
            
        //FIM DAS CONTROLLERS PARA CADASTRO

        //TODAS AS CONTROLLERS CRIADA PARA ALTERAR AS CLASSES UTILIZADAS ATÉ AGORA

        [HttpGet]
        public ActionResult AltCliente(string cpf)
        {
            //PRIMEIRO IRÁ VERIFICAR COM A ID PASSADA NA CONSULTA SE EXISTE E PASSA COMO FORMA PARA ENCONTRAR A SELECT ESPECÍFICA E SEUS DADOS COM O HTTPGET
            var Cpfcli = ac.ListarCliCpf(cpf);
            if (Cpfcli == null)
            {
                return HttpNotFound();
            }
            
            return View(Cpfcli);
        }

        [HttpPost]
        public ActionResult AltCliente(Classe_Cliente cpf)
        {
            //COM A PARTE DO ID DA CONSULTA, É FEITO A TRANSFERÊNCIA DOS CAMPOS DESTAS PARA A O MÉTODO DE ALTERAÇÕES DA AÇÕES POR MEIO DO HTTPOST
            ac.AltCliente(cpf);
            return RedirectToAction("AtividadeSucedida");
        }

        [HttpGet]
        public ActionResult AltFuncio(short cdfun)
        {
            var cdfuncio = ac.ListarFuncProd(cdfun);
            if (cdfuncio == null)
            {
                return HttpNotFound();
            }

            return View(cdfuncio);
        }

        [HttpPost]
        public ActionResult AltFuncio(Classe_Funcionario cdfun)
        {
            ac.AltFuncio(cdfun);
            return RedirectToAction("AtividadeSucedida");
        }

        [HttpGet]
        public ActionResult AltProduto(short produ)
        {
            var cdprod = ac.ListarProdCod(produ);
            if (cdprod == null)
            {
                return HttpNotFound();
            }

            return View(cdprod);
        }

        [HttpPost]
        public ActionResult AltProduto(Classe_Produto produ)
        {
            ac.AltProduto(produ);
            return RedirectToAction("AtividadeSucedida");
        }

        [HttpGet]
        public ActionResult AltCupom(string cupom)
        {
            var cdcupom = ac.ListarCupCod(cupom);
            if (cdcupom == null)
            {
                return HttpNotFound();
            }

            return View(cdcupom);
        }

        [HttpPost]
        public ActionResult AltCupom(Classe_Cupom cupom)
        {
            ac.AltCupom(cupom);
            return RedirectToAction("AtividadeSucedida");
        }

        [HttpGet]
        public ActionResult AltTeste(int test)
        {
            var cdtest = ac.ListarTesCod(test);
            if (cdtest == null)
            {
                return HttpNotFound();
            }

            return View(cdtest);
        }

        [HttpPost]
        public ActionResult AltTeste(Classe_Teste test)
        {
            ac.AltTeste(test);
            return RedirectToAction("AtividadeSucedida");
        }

        [HttpGet]
        public ActionResult AltServico(Int32 serv)
        {
            var cdserv = ac.ListarServCod(serv);
            if (cdserv == null)
            {
                return HttpNotFound();
            }
            return View(cdserv);
        }

        [HttpPost]
        public ActionResult AltServico(Classe_Servico serv)
        {
            ac.AltServico(serv);
            return RedirectToAction("AtividadeSucedida");
        }


        //FIM DAS CONTROLLERS DE ALTERAÇÃO

        //ÍNICIO DAS CONTROLLERS PARA DELETAR AS CLASSES UTILIZADAS ATÉ AGORA

        public ActionResult DelCliente(string cpf)
        {
            //COM A PARTE DO ID DA CONSULTA, É FEITO A TRANSFERÊNCIA DO ID PARA AS AÇÕES PARA DELETAR O SELECT ESPECÍFICO
            ac.DelCliente(cpf);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult DelFuncio(Int16 cdfun)
        {
            ac.DelFuncionario(cdfun);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult DelProduto(Int16 produ)
        {
            ac.DelProduto(produ);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult DelCupom(string cupom)
        {
            ac.DelCupom(cupom);
            return RedirectToAction("AtividadeSucedida");
        }
        
        public ActionResult DelTeste (int testcod)
        {
            ac.DelTeste(testcod);
            return RedirectToAction("AtividadeSucedida");
        }

        public ActionResult DelServico (Int32 serv)
        {
            ac.DelServico(serv);
            return RedirectToAction("AtividadeSucedida");
        }

        /*
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
        //FIM DAS CONTROLLERS PARA DELETAR CLASSES

        //ÍNICIO DAS CONTROLLERS QUE FAZEM CONSULTAS DAS CLASSES UTILIZADAS ATÉ AGORA

        public ActionResult Del_Con_Cliente()
        {
            //ESTÁ REALIZANDO AS INSTÂNCIAS DAS AÇÕES PARA REALIZAR A CONSULTA COM O MÉTODO LISTAR EM GERAL
            var ExibiCliente = new Acoes();
            var TodosClien = ExibiCliente.ListarCli();
            return View(TodosClien);
        }

        public ActionResult Del_Con_Funcio()
        {
            var ExibiFuncio = new Acoes();
            var TodosFuncio = ExibiFuncio.ListarFuncio();
            return View(TodosFuncio);
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

        public ActionResult Del_Con_Teste (Classe_Teste teste)
        {
            var Exibirtes = new Acoes();
            var Todostes = Exibirtes.ListarTes();
            return View(Todostes);
        }
        
        public ActionResult Del_Con_Servico (Classe_Servico serv)
        {
            var Exibirser = new Acoes();
            var Todosserv = Exibirser.ListarServ();
            return View(Todosserv);
        }
        /*
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
        
        //FIM DAS CONTROLLERS DE CONSULTA

        //ESSA CONTROLLER É FEITA PARA CONFIRMAR UMA AÇÃO FEITA DAS AÇÕES, COMO CADASTRAR E ALTERAÇÃO
        public ActionResult AtividadeSucedida()
        {
            return View();
        }

        //CONTROLLERS ABAIXO USADOS PARA IDENTIFICAR UMA SELECT ESPECÍFICA DE OUTRA FORMA
        public ActionResult EncontraCli(string cpf)
        {
            var Exibircli = new Acoes();
            var UMcli = Exibircli.ListarCliCpf(cpf);
            return RedirectToAction("Del_Con_Cliente");
        }

        public ActionResult EncontraProd(Int16 cd)
        {
            var Exibirnome = new Acoes();
            var UMprod = Exibirnome.ListarProdCod(cd);
            return View("Del_Con_Produto");
        }
        
    }
}
