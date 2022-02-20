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
            MySqlCommand cmd = new MySqlCommand("call SPInsertCliente (@vNome_uf,@vNome_Cidade,@vNome_bairro,@vFK_cep_cep,@vLogradouro,@vCli_Cpf,@vCli_Nome,@vCli_NumEnd,@vCli_Email,@vCli_tel)", conectar.ConectarBD());
            cmd.Parameters.Add("@vNome_uf", MySqlDbType.VarChar).Value = cli.Nome_uf;
            cmd.Parameters.Add("@vNome_Cidade", MySqlDbType.VarChar).Value = cli.Nome_cidade;
            cmd.Parameters.Add("@vNome_bairro", MySqlDbType.VarChar).Value = cli.Nome_bairro;
            cmd.Parameters.Add("@vFK_cep_cep", MySqlDbType.VarChar).Value = cli.Cep;
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
            MySqlCommand cmd = new MySqlCommand("call SPInsertFunc (@vNome_uf,@vNome_Cidade,@vNome_bairro,@vFK_cep_cep,@vLogradouro,@vFunc_Nome,@vFunc_CPF,@vFunc_Tel,@vFunc_Email,@vFunc_DataNasc,@vFunc_Num_End,@vFunc_Cargo, @vFunc_senha)", conectar.ConectarBD());
            cmd.Parameters.Add("@vNome_uf", MySqlDbType.VarChar).Value = fun.Nome_uf;
            cmd.Parameters.Add("@vNome_Cidade", MySqlDbType.VarChar).Value = fun.Nome_cidade;
            cmd.Parameters.Add("@vNome_bairro", MySqlDbType.VarChar).Value = fun.Nome_bairro;
            cmd.Parameters.Add("@vFK_cep_cep", MySqlDbType.VarChar).Value = fun.Cep;
            cmd.Parameters.Add("@vLogradouro", MySqlDbType.VarChar).Value = fun.Logradouro;
            cmd.Parameters.Add("@vFunc_Nome", MySqlDbType.VarChar).Value = fun.Func_nome;
            cmd.Parameters.Add("@vFunc_CPF", MySqlDbType.VarChar).Value = fun.Func_cpf;
            cmd.Parameters.Add("@vFunc_Tel", MySqlDbType.LongBlob).Value = fun.Func_tel;
            cmd.Parameters.Add("@vFunc_Email", MySqlDbType.VarChar).Value = fun.Func_email;
            cmd.Parameters.Add("@vFunc_DataNasc", MySqlDbType.DateTime).Value = fun.Func_datanasc;
            cmd.Parameters.Add("@vFunc_Num_End", MySqlDbType.Int32).Value = fun.Func_num_end;
            cmd.Parameters.Add("@vFunc_Cargo", MySqlDbType.VarChar).Value = fun.Func_cargo;
            cmd.Parameters.Add("@vFunc_senha", MySqlDbType.VarChar).Value = fun.Func_senha;
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
            MySqlCommand cmd = new MySqlCommand("call SPInsertTeste(@vRetirada,@vAge_Desc,@vCli_cpf,@vCod_Prod)", conectar.ConectarBD());
            cmd.Parameters.Add("@vRetirada", MySqlDbType.Date).Value = test.Age_DtRetirada;
            cmd.Parameters.Add("@vAge_Desc", MySqlDbType.VarChar).Value = test.Age_Desc;
            cmd.Parameters.Add("@vCli_cpf", MySqlDbType.VarChar).Value = test.Fk_Cliente_Cli_cpf;
            cmd.Parameters.Add("@vCod_Prod", MySqlDbType.VarChar).Value = test.Fk_Produto_Cod_Prod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void CadastroServico (Classe_Servico servico)
        {
            MySqlCommand cmd = new MySqlCommand("call SPInsertServico(@vDesc_Serv,@vProd_Serv,@vDateSaida,@vValor,@vFunc_Cod)", conectar.ConectarBD());
            cmd.Parameters.Add("@vDesc_Serv", MySqlDbType.VarChar).Value = servico.Desc_Serv;
            cmd.Parameters.Add("@vProd_Serv", MySqlDbType.VarChar).Value = servico.Prod_Serv;
            cmd.Parameters.Add("@vDateSaida", MySqlDbType.Date).Value = servico.DateSaida;
            cmd.Parameters.Add("@vValor", MySqlDbType.Float).Value = servico.Valor_servico;
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
            cmd.Parameters.Add("@vVen_Cod", MySqlDbType.Int32).Value = deliver.Fk_Venda_Ven_Cod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        
        
        //ABAIXO ESTÁ OS MÉTODOS DE ALTERAÇÕES DAS CLASSES DISPONÍVEIS
        
        public void AltCliente(Classe_Cliente cpf)
        {
            MySqlCommand cmd = new MySqlCommand("update TBCliente set cli_Nome=@cli_Nome, cli_NumEnd=@cli_NumEnd, cli_email=@cli_email ,cli_Tel=@cli_Tel where cli_cpf=@cli_cpf", conectar.ConectarBD());
            cmd.Parameters.Add("@cli_Nome", MySqlDbType.VarChar).Value = cpf.Cli_nome;
            cmd.Parameters.Add("@cli_NumEnd", MySqlDbType.Int32).Value = cpf.Cli_numEnd;
            cmd.Parameters.Add("@cli_email", MySqlDbType.VarChar).Value = cpf.Cli_email;
            cmd.Parameters.Add("@cli_Tel", MySqlDbType.LongBlob).Value = cpf.Cli_tel;
            cmd.Parameters.Add("@cli_cpf", MySqlDbType.VarChar).Value = cpf.Cli_cpf;

            //cmd.Parameters.Add("@fk_fidelidade_Brinde_cod", MySqlDbType.int).Value = ;
            //cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        
        public void AltFuncio(Classe_Funcionario cdfun)
        {
            MySqlCommand cmd = new MySqlCommand("update TBFuncionario set func_Nome=@func_Nome, func_Tel=@func_Tel, func_Email=@func_Email, func_DataNasc=@func_DataNasc, func_Num_End=@func_Num_End, func_Cargo=@func_Cargo where func_Cod=@Func_cod", conectar.ConectarBD());
            cmd.Parameters.Add("@func_Nome", MySqlDbType.VarChar).Value = cdfun.Func_nome;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.LongBlob).Value = cdfun.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.VarChar).Value = cdfun.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.Date).Value = cdfun.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.Int32).Value = cdfun.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.VarChar).Value = cdfun.Func_cargo;
            cmd.Parameters.Add("@Func_cod", MySqlDbType.Int16).Value = cdfun.Func_cod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        public void AltProduto(Classe_Produto produ)
        {
            MySqlCommand cmd = new MySqlCommand("update TBProduto set prod_Nome=@prod_Nome, prod_Tipo=@prod_Tipo, prod_Quant_Estoque=@prod_Quant_Estoque, prod_Desc=@prod_Desc, prod_AnoLanc=@prod_AnoLanc, prod_FaixaEta=@prod_FaixaEta, prod_Valor=@prod_Valor where cod_Prod=@cod_prod", conectar.ConectarBD());
            cmd.Parameters.Add("@prod_Nome", MySqlDbType.VarChar).Value = produ.Prod_nome;
            cmd.Parameters.Add("@prod_Tipo", MySqlDbType.VarChar).Value = produ.Prod_tipo;
            cmd.Parameters.Add("@prod_Quant_Estoque", MySqlDbType.Int32).Value = produ.Prod_quant_estoque;
            cmd.Parameters.Add("@prod_Desc", MySqlDbType.VarChar).Value = produ.Prod_desc;
            cmd.Parameters.Add("@prod_AnoLanc", MySqlDbType.VarChar).Value = produ.Prod_anolanc;
            cmd.Parameters.Add("@prod_FaixaEta", MySqlDbType.VarChar).Value = produ.Prod_faixaeta;
            cmd.Parameters.Add("@prod_Valor", MySqlDbType.Decimal).Value = produ.Prod_valor;
            cmd.Parameters.Add("@cod_prod", MySqlDbType.Int16).Value = produ.Cod_prod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void AltCupom(Classe_Cupom cup)
        {
            MySqlCommand cmd = new MySqlCommand("update TBCupom set descontoCupom=@descontoCupom where cupom_cod=@cupom_cod ", conectar.ConectarBD());
            cmd.Parameters.Add("@descontoCupom", MySqlDbType.Float).Value = cup.DescontoCupom;
            cmd.Parameters.Add("@cupom_cod", MySqlDbType.VarChar).Value = cup.Cupom_cod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        public void AltTeste(Classe_Teste test)
        {
            MySqlCommand cmd = new MySqlCommand("update TBTeste set age_DtRetirada=@age_DtRetirada, age_Desc=@age_Desc, fk_Cliente_Cli_cpf=@fk_Cliente_Cli_cpf, fk_Produto_Cod_Prod=@fk_Produto_Cod_Prod where agen_Cod=@agen_Cod ", conectar.ConectarBD());
            cmd.Parameters.Add("@age_DtRetirada", MySqlDbType.Date).Value = test.Age_DtRetirada;
            cmd.Parameters.Add("@age_Desc", MySqlDbType.VarChar).Value = test.Age_Desc;
            cmd.Parameters.Add("@fk_Cliente_Cli_cpf", MySqlDbType.VarChar).Value = test.Fk_Cliente_Cli_cpf;
            cmd.Parameters.Add("@fk_Produto_Cod_Prod", MySqlDbType.Int32).Value = test.Fk_Produto_Cod_Prod;
            cmd.Parameters.Add("@agen_Cod", MySqlDbType.Int32).Value = test.Agen_Cod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        public void AltServico(Classe_Servico serv)
        {
            MySqlCommand cmd = new MySqlCommand("update TBServico set desc_Serv=@desc_Serv, prod_Serv=@prod_Serv, dateEntre=@DateEntre, dateSaida=@DateSaida, valor_servico=@valor_servico, fk_Funcionario_Func_Cod=@FK_Funcionario_Func_Cod", conectar.ConectarBD());
            cmd.Parameters.Add("@desc_Serv", MySqlDbType.VarChar).Value = serv.Desc_Serv;
            cmd.Parameters.Add("@prod_Serv", MySqlDbType.VarChar).Value = serv.Prod_Serv;
            cmd.Parameters.Add("@DateEntre", MySqlDbType.Date).Value = serv.DateEntre;
            cmd.Parameters.Add("@DateSaida", MySqlDbType.Date).Value = serv.DateSaida;
            cmd.Parameters.Add("@valor_servico", MySqlDbType.Float).Value = serv.Valor_servico;
            cmd.Parameters.Add("@FK_Funcionario_Func_Cod", MySqlDbType.Int32).Value = serv.Fk_Funcionario_Func_Cod;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();

        }

        //ABAIXO ESTÁ OS MÉTODOS QUE DELETA DAS CLASSES DISPONÍVEIS

        public void DelCliente(string cpf)
        {
            var deletacl = String.Format("call SPDeleteCliente ('{0}')", cpf);
            MySqlCommand cmd = new MySqlCommand(deletacl, conectar.ConectarBD());
            cmd.ExecuteReader();
        }
        
        public void DelFuncionario(Int16 cdfun)
        {
            var deletafn = String.Format("call SPDeleteFunc ('{0}')", cdfun);
            MySqlCommand cmd = new MySqlCommand(deletafn, conectar.ConectarBD());
            cmd.ExecuteReader();
        }
        
        
        public void DelProduto(Int16 cd)
        {
            var deletapd = String.Format("call SPDeleteProd ('{0}')", cd);
            MySqlCommand cmd = new MySqlCommand(deletapd, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelCupom(string cupom)
        {
            var deletacp = String.Format("call SPDeleteCupom ('{0}')", cupom);
            MySqlCommand cmd = new MySqlCommand(deletacp, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelTeste (int testcod)
        {
            var deletag = String.Format("delete from TBTeste where agen_Cod = {0}", testcod);
            MySqlCommand cmd = new MySqlCommand(deletag, conectar.ConectarBD());
            cmd.ExecuteReader();
        }

        public void DelServico (Int32 serv)
        {
            var deletaserv = String.Format("delete from TBServico where cod_Serv = {0}", serv);
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
            var comando = String.Format("select * from TBCliente where cli_cpf = '{0}'", cpf);
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
                    FK_cep_cep = dr["FK_cep_cep"].ToString(),
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
        public Classe_Funcionario ListarFuncProd(Int16 cdfun)
        {
            var comando = String.Format("Select * from TBFuncionario where func_cod = {0}", cdfun);
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
                    Func_cod = Int16.Parse(dr["Func_cod"].ToString()),
                    Func_nome = dr["Func_nome"].ToString(),
                    Func_cpf = dr["Func_cpf"].ToString(),
                    Func_tel = long.Parse(dr["Func_tel"].ToString()),
                    Func_email = dr["Func_email"].ToString(),
                    Func_datanasc = DateTime.Parse(dr["Func_datanasc"].ToString()),
                    Func_num_end = Int16.Parse(dr["Func_num_end"].ToString()),
                    Func_cargo = dr["Func_cargo"].ToString(),
                    Func_senha = dr["Func_senha"].ToString(),
                    FK_cep_cep = dr["FK_cep_cep"].ToString(),
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
        public Classe_Produto ListarProdCod(int produ)
        {
            var comando = String.Format("select*from TBProduto where cod_Prod = {0}", produ);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosProdCod = cmd.ExecuteReader();
            return ListarProduto(DadosProdCod).FirstOrDefault();
        }

        public Classe_Produto ListarNomeCod(string nome)
        {
            var comando = String.Format("select*from TBProduto where prod_Nome = '{0}'", nome);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosNomeCod = cmd.ExecuteReader();
            return ListarProduto(DadosNomeCod).FirstOrDefault();
        }

        //LISTAR TODOS OS PRODUTOS DO BANCO
        public List<Classe_Produto> ListarProduto(MySqlDataReader dr)
        {
            var ListProd = new List<Classe_Produto>();
            while (dr.Read())
            {
                var ProdTemp = new Classe_Produto()
                {
                    Cod_prod = Int16.Parse(dr["cod_Prod"].ToString()),
                    Prod_nome = dr["Prod_nome"].ToString(),
                    Prod_tipo = dr["Prod_tipo"].ToString(),
                    Prod_quant_estoque = Int16.Parse(dr["Prod_quant_estoque"].ToString()),
                    Prod_desc = dr["Prod_desc"].ToString(),
                    Prod_anolanc = dr["Prod_anolanc"].ToString(),
                    Prod_faixaeta = dr["Prod_faixaeta"].ToString(),
                    Prod_valor = float.Parse(dr["Prod_valor"].ToString()),
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
            var comando = String.Format("Select * from TBCupom where cupom_cod = '{0}'", cupom);
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

        public List<Classe_Servico> ListarServ()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from TBServico", conectar.ConectarBD());
            var dadosservico = cmd.ExecuteReader();
            return ListarServico(dadosservico);
        }

        public Classe_Servico ListarServCod(int servcod)
        {
            var comando = String.Format("Select * from TBServico where cod_Serv = {0}", servcod);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosServCod = cmd.ExecuteReader();
            return ListarServico(DadosServCod).FirstOrDefault();
        }

        public List<Classe_Servico> ListarServico(MySqlDataReader dr)
        {
            var ListServ = new List<Classe_Servico>();
            while(dr.Read())
            {
                var ServTemp = new Classe_Servico()
                {
                    Cod_Serv = Int32.Parse(dr["cod_Serv"].ToString()),
                    Desc_Serv = dr["desc_Serv"].ToString(),
                    Prod_Serv = dr["prod_Serv"].ToString(),
                    DateEntre = DateTime.Parse(dr["dateEntre"].ToString()),
                    DateSaida = DateTime.Parse(dr["dateSaida"].ToString()),
                    Valor_servico = float.Parse(dr["valor_servico"].ToString()),
                    Fk_Funcionario_Func_Cod = Int32.Parse(dr["fk_Funcionario_Func_Cod"].ToString())
                };
                ListServ.Add(ServTemp);
            }
            dr.Close();
            return ListServ;
        }

        public List<Classe_Teste> ListarTes()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from TBTeste", conectar.ConectarBD());
            var dadosteste = cmd.ExecuteReader();
            return ListarTestes(dadosteste);
        }

        public Classe_Teste ListarTesCod(int agecod)
        {
            var comando = String.Format("Select * from TBTeste where agen_Cod = {0}", agecod);
            MySqlCommand cmd = new MySqlCommand(comando, conectar.ConectarBD());
            var DadosTesCod = cmd.ExecuteReader();
            return ListarTestes(DadosTesCod).FirstOrDefault();
        }

        public List<Classe_Teste> ListarTestes(MySqlDataReader dr)
        {
            var ListTes = new List<Classe_Teste>();
            while (dr.Read())
            {
                var TesTemp = new Classe_Teste()
                {
                    Agen_Cod = int.Parse(dr["agen_Cod"].ToString()),
                    Age_DtRetirada = DateTime.Parse(dr["Age_DtRetirada"].ToString()),
                    Age_Desc = dr["Age_Desc"].ToString(),
                    Fk_Cliente_Cli_cpf = dr["Fk_Cliente_Cli_cpf"].ToString(),
                    Fk_Produto_Cod_Prod = int.Parse(dr["Fk_Produto_Cod_Prod"].ToString())
                };
                ListTes.Add(TesTemp);
            }
            dr.Close();
            return ListTes;
            
        }

       

        
    }
}
