using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GAME_WAVE___SISTEMA_ASP_NET.Models;


namespace GAME_WAVE___SISTEMA_ASP_NET.Repositorio
{

    public class Acoes
    {
        Conexaosql conectar = new Conexaosql();
        MySqlCommand cmd = new MySqlCommand();

        public Classe_Funcionario VerificacaoFuncionario(Classe_Funcionario funcio)
        {
            MySqlCommand cmd = new MySqlCommand("select *from TBFuncionario where func_CPF=@func_CPF and func_senha = @func_senha", conectar.ConectarBD());
            cmd.Parameters.Add("@func_CPF", MySqlDbType.VarChar).Value = funcio.Func_cpf;
            cmd.Parameters.Add("@func_senha", MySqlDbType.VarChar).Value = funcio.Func_senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Classe_Funcionario fun = new Classe_Funcionario();
                    {
                        fun.Func_cpf = Convert.ToString(leitor["func_CPF"]);
                        fun.Func_senha = Convert.ToString(leitor["func_senha"]);
                    }
                }
            }
            else
            {
                funcio.Func_cpf = null;
                funcio.Func_senha = null;
            }
            return funcio;
        }

        /* Incompleto BD, esperando a revisão da análise */
        
        public void CadastrarCliente(Classe_Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertCliente (@vNome_uf,@vNome_Cidade,@vNome_bairro,@vCep,@vLogradouro,@vCli_Cpf,@vCli_Nome,@vCli_NumEnd,@vCli_Email,@vCli_tel,@vCep)", conectar.ConectarBD());
            cmd.Parameters.Add("@vNome_uf", MySqlDbType.VarChar).Value = cli.Nome_uf;
            cmd.Parameters.Add("@vNome_Cidade", MySqlDbType.VarChar).Value = cli.Nome_cidade;
            cmd.Parameters.Add("@vNome_bairro", MySqlDbType.VarChar).Value = cli.Nome_bairro;
            cmd.Parameters.Add("@vCep", MySqlDbType.VarChar).Value = cli.Cep;
            cmd.Parameters.Add("@vLogradouro", MySqlDbType.VarChar).Value = cli.Logradouro;
            cmd.Parameters.Add("@vCli_Cpf", MySqlDbType.VarChar).Value = cli.Cli_cpf;
            cmd.Parameters.Add("@vCli_Nome", MySqlDbType.VarChar).Value = cli.Cli_nome;
            cmd.Parameters.Add("@vCli_NumEnd", MySqlDbType.Int32).Value = cli.Cli_numEnd;
            cmd.Parameters.Add("@vCli_Email", MySqlDbType.VarChar).Value = cli.Cli_email;
            cmd.Parameters.Add("@vCli_tel", MySqlDbType.LongBlob).Value = cli.Cli_tel;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        
        public void CadastrarFuncio(Classe_Funcionario fun)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertFunc (@vNome_uf,@vNome_Cidade,@vNome_bairro,@vCep,@vLogradouro,@vFunc_Nome,@vFunc_CPF,@vFunc_Tel,@vFunc_Email,@vFunc_DataNasc,@vFunc_Num_End,@vFunc_Cargo, @vFunc_senha, @vCep)", conectar.ConectarBD());
            cmd.Parameters.Add("@vNome_uf", MySqlDbType.VarChar).Value = fun.Nome_uf;
            cmd.Parameters.Add("@vNome_Cidade", MySqlDbType.VarChar).Value = fun.Nome_cidade;
            cmd.Parameters.Add("@vNome_bairro", MySqlDbType.VarChar).Value = fun.Nome_bairro;
            cmd.Parameters.Add("@vCep", MySqlDbType.VarChar).Value = fun.Cep;
            cmd.Parameters.Add("@vLogradouro", MySqlDbType.VarChar).Value = fun.Logradouro;
            cmd.Parameters.Add("@func_Nome", MySqlDbType.VarChar).Value = fun.Func_nome;
            cmd.Parameters.Add("@func_CPF", MySqlDbType.VarChar).Value = fun.Func_cpf;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.LongBlob).Value = fun.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.VarChar).Value = fun.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.DateTime).Value = fun.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.Int32).Value = fun.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.VarChar).Value = fun.Func_cargo;
            cmd.Parameters.Add("@func_senha", MySqlDbType.VarChar).Value = fun.Func_senha;
            //cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.varchar).Value = fun.Cep;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        public void CadastroProduto(Classe_Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertProduto (@vProd_Nome,@vProd_Tipo,@vProd_Quant_Estoque,@vProd_Desc,@vProd_AnoLanc,@vProd_FaixaEta,@vProd_Valor)", conectar.ConectarBD());
            cmd.Parameters.Add("@vProd_Nome", MySqlDbType.VarChar).Value = prod.Prod_nome;
            cmd.Parameters.Add("@vProd_Tipo", MySqlDbType.VarChar).Value = prod.Prod_tipo;
            cmd.Parameters.Add("@vProd_Quant_Estoque", MySqlDbType.Int32).Value = prod.Prod_quant_estoque;
            cmd.Parameters.Add("@vProd_Desc", MySqlDbType.VarChar).Value = prod.Prod_desc;
            cmd.Parameters.Add("@vProd_AnoLanc", MySqlDbType.VarChar).Value = prod.Prod_anolanc;
            cmd.Parameters.Add("@vProd_FaixaEta", MySqlDbType.VarChar).Value = prod.Prod_faixaeta;
            cmd.Parameters.Add("@vProd_Valor", MySqlDbType.Decimal).Value = prod.Prod_valor;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void CadastroCupom (Classe_Cupom cup)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBCupom values (@cupom_cod,@descontoCupom)", conectar.ConectarBD());
            cmd.Parameters.Add("@cupom_cod", MySqlDbType.VarChar).Value = cup.Cupom_cod;
            cmd.Parameters.Add("@descontoCupom", MySqlDbType.Float).Value = cup.DescontoCupom;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void CadastroTeste (Classe_Teste test)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertTeste(@vAge_Desc,@vCli_cpf,@vCod_Prod)", conectar.ConectarBD());
            cmd.Parameters.Add("@vAge_Desc", MySqlDbType.VarChar).Value = test.Age_Desc;
            cmd.Parameters.Add("@vCli_cpf", MySqlDbType.VarChar).Value = test.Fk_Cliente_Cli_cpf;
            cmd.Parameters.Add("@vCod_Prod", MySqlDbType.Int32).Value = test.Fk_Produto_Cod_Prod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void CadastroServico (Classe_Servico servico)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertServico(@vDesc_Serv,@vProd_Serv,@vDateSaida,@vValor,@vFunc_Cod)", conectar.ConectarBD());
            cmd.Parameters.Add("@vDesc_Serv", MySqlDbType.VarChar).Value = servico.Desc_Serv;
            cmd.Parameters.Add("@vProd_Serv", MySqlDbType.VarChar).Value = servico.Prod_Serv;
            cmd.Parameters.Add("@vDateSaida", MySqlDbType.Date).Value = servico.DateSaida;
            cmd.Parameters.Add("@vValor", MySqlDbType.Decimal).Value = servico.Valor_servico;
            cmd.Parameters.Add("@vFunc_Cod", MySqlDbType.Int32).Value = servico.Fk_Funcionario_Func_Cod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void CadastroVenda (Classe_Venda vend)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertiniciaVenda(1,'Dinheiro', 00.00");
        }

        public void CadastroDelivery (Classe_Delivery deliver)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertDelivey(@vCli_cpf,@vVen_Cod", conectar.ConectarBD());
            cmd.Parameters.Add("@vCli_cpf", MySqlDbType.VarChar).Value = deliver.Fk_Cliente_Cli_cpf;
            cmd.Parameters.Add("@vVen_Cod", MySqlDbType.Int32).Value = deliver.Fk_Venda_Ven_Cid;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        
        
        //ABAIXO ESTÁ OS MÉTODOS DE ALTERAÇÕES DAS CLASSES DISPONÍVEIS
        
        public void AltCliente(Classe_Cliente clien)
        {
            MySqlCommand cmd = new MySqlCommand("update TBCliente set cli_Nome=@cli_Nome, cli_NumEnd=@cli_NumEnd, cli_Tel=@cli_Tel where Cli_cpf=@cli_cpf", conectar.ConectarBD());
            cmd.Parameters.Add("@cli_Nome", MySqlDbType.VarChar).Value = clien.Cli_nome;
            cmd.Parameters.Add("@cli_NumEnd", MySqlDbType.Int32).Value = clien.Cli_numEnd;
            cmd.Parameters.Add("@cli_Tel", MySqlDbType.LongBlob).Value = clien.Cli_tel;
            //cmd.Parameters.Add("@fk_fidelidade_Brinde_cod", MySqlDbType.int).Value = ;
            //cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        
        public void AltFuncio(Classe_Funcionario funci)
        {
            MySqlCommand cmd = new MySqlCommand("update TBFuncionario set func_Nome=@func_Nome, func_Tel=@func_Tel, func_Email=@func_Email, func_DataNasc=@func_DataNasc, func_Num_End=@func_Num_End, func_Cargo=@func_Cargo, fk_Cep_cep=@fk_Cep_cep where Func_CPF=@func_Cpf", conectar.ConectarBD());
            cmd.Parameters.Add("@func_Nome", MySqlDbType.VarChar).Value = funci.Func_nome;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.LongBlob).Value = funci.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.VarChar).Value = funci.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.DateTime).Value = funci.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.Int32).Value = funci.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.VarChar).Value = funci.Func_cargo;
            cmd.Parameters.Add("@func_senha", MySqlDbType.VarChar).Value = funci.Func_senha;
            cmd.Parameters.Add("@Cep", MySqlDbType.VarChar).Value = funci.Cep;
            //cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        public void AltProduto(Classe_Produto produ)
        {
            MySqlCommand cmd = new MySqlCommand("update TBProduto set prod_Nome=@prod_Nome, prod_Tipo=@prod_Tipo, prod_Quant_Estoque=@prod_Quant_Estoque, prod_Desc=@prod_Desc, prod_AnoLanc=@prod_AnoLanc, prod_FaixaEta=@prod_FaixaEta, prod_Valor=@prod_Valor where Cod_pro=@cod_pROD", conectar.ConectarBD());
            cmd.Parameters.Add("@prod_Nome", MySqlDbType.VarChar).Value = produ.Prod_nome;
            cmd.Parameters.Add("@prod_Tipo", MySqlDbType.VarChar).Value = produ.Prod_tipo;
            cmd.Parameters.Add("@prod_Quant_Estoque", MySqlDbType.Int32).Value = produ.Prod_quant_estoque;
            cmd.Parameters.Add("@prod_Desc", MySqlDbType.VarChar).Value = produ.Prod_desc;
            cmd.Parameters.Add("@prod_AnoLanc", MySqlDbType.VarChar).Value = produ.Prod_anolanc;
            cmd.Parameters.Add("@prod_FaixaEta", MySqlDbType.VarChar).Value = produ.Prod_faixaeta;
            cmd.Parameters.Add("@prod_Valor", MySqlDbType.Decimal).Value = produ.Prod_valor;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        
        //ABAIXO ESTÁ OS MÉTODOS QUE DELETA DAS CLASSES DISPONÍVEIS
        
        public void DelCliente(string cpf)
        {
            var deletacl = String.Format("delete from TBCliente where cli_cpf = {0}", cpf);
            MySqlCommand cmd = new MySqlCommand(deletacl, conectar.ConectarBD());
            cmd.ExecuteReader();
        }
        
        public void DelFuncionario(Classe_Funcionario funciocod)
        {
            var deletafn = String.Format("delete from TBFuncionario where func_Cod = {0}", funciocod);
            MySqlCommand cmd = new MySqlCommand(deletafn, conectar.ConectarBD());
            cmd.ExecuteReader();
        }
        
        
        public void DelProduto(Classe_Produto produtcod)
        {
            var deletapd = String.Format("delete from TBProduto where Cod_Prod = {0}", produtcod);
            MySqlCommand cmd = new MySqlCommand(deletapd, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelCupom(Classe_Cupom cupcod)
        {
            var deletacp = String.Format("delete from TBCupom where cupom_cod = {0}", cupcod);
            MySqlCommand cmd = new MySqlCommand(deletacp, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelTeste (Classe_Teste testcod)
        {
            var deletag = String.Format("delete from TBTeste where agen_Cod = {0}", testcod);
            MySqlCommand cmd = new MySqlCommand(deletag, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelServico (Classe_Servico servcod)
        {
            var deletaserv = String.Format("delete from TBServico where cod_Serv = {0}", servcod);
            MySqlCommand cmd = new MySqlCommand(deletaserv, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelDelivery (Classe_Delivery delicod)
        {
            var deletadeli = String.Format("delete from TBDelivery where deli_Cod = {0}", delicod);
            MySqlCommand cmd = new MySqlCommand(deletadeli, conectar.ConectarBD());
            cmd.ExecuteReader();
        }
        
        
        //INÍCIO DAS CONSULTAS DAS CLASSES DISPONÍVEIS
         
        //Ínicio à Cliente
        //APENAS LISTA OS CLIENTES                                 
        public List<Classe_Cliente> ListarCli()
        {
            MySqlCommand cmd = new MySqlCommand("Select*from TBCliente", conectar.ConectarBD());
            var dadoscli = cmd.ExecuteReader();
            return ListarCliente(dadoscli);
        }
        
        //MÉTODO PARA LISTAR OS CLIENTES POR CPF

        public Classe_Cliente ListarCliCpf(string cpf)
        {
            var comando = String.Format("select * from TBCliente where cli_cpf = {0}", cpf);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var ClienCpf = cmd.ExecuteReader();
            return ListarCliente(ClienCpf).FirstOrDefault();
        }
                                         
        //MÉTODO PARA LISTAR TODOS OS CLIENTES DO BD
        public List<Classe_Cliente> ListarCliente(MySqlDataReader dr)                                
        {
            var ListCli = new List <Classe_Cliente>();
            while (dr.Read())
            {
                var CliTemp = new Classe_Cliente()
                {
                    Cli_cpf = dr["Cli_cpf"].ToString(),
                    Cli_nome = dr["Cli_nome"].ToString(),
                    Cli_numEnd = Int16.Parse(dr["Cli_numEnd"].ToString()),
                    Cli_email = dr["Cli_email"].ToString(),
                    Cli_tel = long.Parse(dr["Cli_tel"].ToString()),
                    //fk_Cep_cep = dr["Cep"].ToString(),
                };
                ListCli.Add(CliTemp);
            }
            dr.Close();
            return ListCli;
        }
        
                                         
        //FIM DA CLASSE CLIENTE
        //ÍNICIO DA CLASSE FUNCIONÁRIO
        
        //APENAS O MÉTODO DA LISTA DE FUNCIONÁRIO                                
        public List<Classe_Funcionario> ListarFuncio()
        {
            MySqlCommand cmd = new MySqlCommand("Select*from TBFuncionario", conectar.ConectarBD());
            var dadosfun = cmd.ExecuteReader();
            return ListarFuncionario(dadosfun);
        }
        
        //MÉTODO PARA LISTAR O FUNCIONÁRIO COM SEU COD
        public Classe_Funcionario ListarFuncProd(int cdfun)
        {
            var comando = String.Format("Select * from TBFuncionario where func_Cod = {0}", cdfun);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var FuncCod = cmd.ExecuteReader();
            return ListarFuncionario(FuncCod).FirstOrDefault();
        }
                                         
        //MÉTODO PARA LISTAR TODOS OS FUNCIONÁRIOS do bd
        public List<Classe_Funcionario> ListarFuncionario(MySqlDataReader dr)
        {
            var ListFun = new List <Classe_Funcionario>();
            while (dr.Read())
            {
                var FunTemp = new Classe_Funcionario()
                {
                    //Func_Cod = default,
                    Func_nome = dr["Func_nome"].ToString(),
                    Func_cpf = dr["Func_cpf"].ToString(),
                    Func_tel = long.Parse(dr["Func_tel"].ToString()),
                    Func_email = dr["Func_email"].ToString(),
                    Func_datanasc = DateTime.Parse(dr["Func_datanasc"].ToString()),
                    Func_num_end = Int16.Parse(dr["Func_num_end"].ToString()),
                    Func_cargo = dr["Func_cargo"].ToString(),
                    Func_senha = dr["Func_senha"].ToString(),
                    //fk_Cep_cep = dr["Cep"].ToString()),
                };
                ListFun.Add(FunTemp);
            }
            dr.Close();
            return ListFun;
        }
                                         
        //FIM DA CLASSE FUNCIONÁRIO
                                         
        //Ínicio da Classe Produto
        
                                         
        //Apenas O método para listar a classe produtos                                 
        public List<Classe_Produto> ListarProd()
        {
            MySqlCommand cmd = new MySqlCommand("Select*from TBProduto", conectar.ConectarBD());
            var dadospro = cmd.ExecuteReader();
            return ListarProduto(dadospro);
        }        
        
        //MÉTODO PARA LISTAR OS PRODUTOS COM O CÓDIGO
        public Classe_Produto ListarProdCod(int cdpro)
        {
            var comando = String.Format("select*from TBProduto where cod_Prod = {0}", cdpro);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosProdCod = cmd.ExecuteReader();
            return ListarProduto(DadosProdCod).FirstOrDefault();
        }
                                         
        //LISTAR TODOS OS PRODUTOS DO BANCO
         public List<Classe_Produto> ListarProduto(MySqlDataReader dr)
        {
            var ListProd = new List<Classe_Produto>();
            while (dr.Read())
            {
                var ProdTemp = new Classe_Produto()
                {
                    //Cod_Prod = default,
                    Prod_nome = dr["Prod_nome"].ToString(),
                    Prod_tipo = dr["Prod_tipo"].ToString(),
                    Prod_quant_estoque = Int16.Parse(dr["Prod_quant_estoque"].ToString()),
                    Prod_desc = dr["Prod_desc"].ToString(),
                    Prod_anolanc = dr["Prod_anolanc"].ToString(),
                    Prod_faixaeta = dr["Prod_faixaeta"].ToString(),
                    Prod_valor = decimal.Parse(dr["Prod_valor"].ToString()),
                };
                ListProd.Add(ProdTemp);
            }
            dr.Close();
            return ListProd;
        }
        
        public List<Classe_Cupom> ListarCup()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from TBCupom", conectar.ConectarBD());
            var dadoscup = cmd.ExecuteReader();
            return ListarCupom(dadoscup);
        }

        public Classe_Cupom ListarCupCod(string cupom)
        {
            var comando = String.Format("Select * from TBCupom where cupom_cod = {0}", cupom);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosCupCod = cmd.ExecuteReader();
            return ListarCupom(DadosCupCod).FirstOrDefault();
        }

        public List<Classe_Cupom> ListarCupom(MySqlDataReader dr)
        {
            var ListCup = new List<Classe_Cupom>();
            while(dr.Read())
            {
                var CupTemp = new Classe_Cupom()
                {
                    Cupom_cod = dr["Cupom_cod"].ToString(),
                    DescontoCupom = float.Parse(dr["DescontoCupom"].ToString()),
                };
                ListCup.Add(CupTemp);
            }
            dr.Close();
            return ListCup;
        }

        /**/

        public List<Classe_Teste> ListarTes()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from vm_Testes", conectar.ConectarBD());
            var dadosteste = cmd.ExecuteReader();
            return ListarTestes(dadosteste);
        }

        public Classe_Teste ListarTesCod(int agecod)
        {
            var comando = String.Format("Select * from vm_Testes where agen_Cod = {0}", agecod);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosTesCod = cmd.ExecuteReader();
            return ListarTestes(DadosTesCod).FirstOrDefault();
        }

        public List<Classe_Teste> ListarTestes(MySqlDataReader dr)
        {
            var ListTes = new List<Classe_Teste>();
            var ListProd = new List<Classe_Produto>();
            var ListClien = new List<Classe_Cliente>();
            while (dr.Read())
            {
                var TesTemp = new Classe_Teste()
                {
                    Agen_Cod = Int16.Parse(dr["Agen_Cod"].ToString()),
                    Age_DtRetirada = DateTime.Parse(dr["Age_DtRetirada"].ToString()),
                    Age_Desc = dr["Age_Desc"].ToString(),
                };
                ListTes.Add(TesTemp);
            }
            dr.Close();
            return ListTes;
            
        }

        public List<Classe_Servico> ListarSer()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from vm_Servico", conectar.ConectarBD());
            var dadosservico = cmd.ExecuteReader();
            return ListarServico(dadosservico);
        }

        public Classe_Servico ListarSerCod(int codserv)
        {
            var comando = String.Format("Select * from vm_Servico where cod_Serv = {0}", codserv);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosSerCod = cmd.ExecuteReader();
            return ListarServico(DadosSerCod).FirstOrDefault();
        }

        public List<Classe_Servico> ListarServico(MySqlDataReader dr)
        {
            var ListSer = new List<Classe_Servico>();
            while (dr.Read())
            {
                var SerTemp = new Classe_Servico()
                {
                    
                };
                ListSer.Add(SerTemp);
            }
            dr.Close();
            return ListSer;

        }
    }
}
