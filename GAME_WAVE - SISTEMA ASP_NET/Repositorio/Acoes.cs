using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAME_WAVE___SISTEMA_ASP_NET.Repositorio;
using MySql.Data.MySqlClient;
using GAME_WAVE___SISTEMA_ASP_NET.Models;


namespace GAME_WAVE___SISTEMA_ASP_NET.Controllers
{

    public class Acoes
    {
        Conexaosql conectar = new Conexaosql();
        MySqlCommand cmd = new MySqlCommand();

        /* Incompleto BD, esperando a revisão da análise */
        
        public void CadastrarCliente(Classe_Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBCliente values(@cli_Cpf,@cli_Nome,@cli_NumEnd,@cli_Email,@cli_Tel,@fk_fidelidade_Brinde_cod,@fk_Cep_cep)", con.ConectarBD());
            cmd.Parameters.Add("@cli_Cpf", MySqlDbType.numeric).Value = cli.Cli_cpf;
            cmd.Parameters.Add("@cli_Nome", MySqlDbType.varchar).Value = cli.Cli_Nome;
            cmd.Parameters.Add("@cli_NumEnd", MySqlDbType.int).Value = cli.Cli_numEnd;
            cmd.Parameters.Add("@cli_Email", MySqlDbType.varchar).Value = cli.Cli_email;
            cmd.Parameters.Add("@cli_Tel", MySqlDbType.numeric).Value = cli.Cli_tel;
            cmd.Parameters.Add("@fk_fidelidade_Brinde_cod", MySqlDbType.int).Value = ;
            cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            cmd.DesconectarBD();
        }
        
        public void CadastrarFuncio(Classe_Funcionario fun)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBFuncionario values(default,@func_Nome,@func_CPF,@func_Tel,@func_Email,@func_DataNasc,@func_Num_End,@func_Cargo,@fk_Cep_cep")", con.ConectarBD());
            cmd.Parameters.Add("@func_Nome", MySqlDbType.varchar).Value = fun.Func_nome;
            cmd.Parameters.Add("@func_CPF", MySqlDbType.numeric).Value = fun.Func_cpf;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.numeric).Value = fun.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.varchar).Value = fun.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.DateTime).Value = fun.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.int).Value = fun.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.varchar).Value = fun.Func_cargp;
            cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.varchar).Value = fun.Cep;
            cmd.ExecuteNonQuery();
            cmd.DesconectarBD();
        }
        
        public void CadastroProduto(Classe_Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBProduto values(default,@prod_Nome,@prod_Tipo,@prod_Quant_Estoque,@prod_Desc,@prod_AnoLanc,@prod_FaixaEta,@prod_Valor")", con.ConectarBD());
            cmd.Parameters.Add("@prod_Nome", MySqlDbType.varchar).Value = prod.Prod_nome;
            cmd.Parameters.Add("@prod_Tipo", MySqlDbType.varchar).Value = prod.Prod_tipo;
            cmd.Parameters.Add("@prod_Quant_Estoque", MySqlDbType.int).Value = prod.Prod_quant_estoque;
            cmd.Parameters.Add("@prod_Desc", MySqlDbType.varchar).Value = prod.Prod_desc;
            cmd.Parameters.Add("@prod_AnoLanc", MySqlDbType.varchar).Value = prod.Prod_anolanc;
            cmd.Parameters.Add("@prod_FaixaEta", MySqlDbType.varchar).Value = prod.Prod_nome;
            cmd.Parameters.Add("@prod_Valor", MySqlDbType.decimal).Value = prod.Prod_valor;
            cmd.ExecuteNonQuery();
            cmd.DesconectarBD();
        }
        
        //ABAIXO ESTÁ OS MÉTODOS DE ALTERAÇÕES DAS CLASSES DISPONÍVEIS
        
        public void AltCliente(Classe_Cliente clien)
        {
            MySqlCommand cmd = new MySqlCommand("update TBCliente set cli_Nome=@cli_Nome, cli_NumEnd=@cli_NumEnd, cli_Tel=@cli_Tel, fk_Fidelidade_Brinde_cod=@fk_Fidelidade_Brinde_cod, fk_Cep_cep=@fk_Cep_cep where Cli_cpf=@cli_Cpf", con.ConectarBD());
            cmd.Parameters.Add("@cli_Nome", MySqlDbType.numeric).Value = clien.Cli_Nome;
            cmd.Parameters.Add("@cli_NumEnd", MySqlDbType.int).Value = clien.Cli_numEnd;
            cmd.Parameters.Add("@cli_Tel", MySqlDbType.numeric).Value = clien.Cli_tel;
            cmd.Parameters.Add("@fk_fidelidade_Brinde_cod", MySqlDbType.int).Value = ;
            cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            cmd.DesconectarBD();
        }
        
        public void AltFuncio(Classe_Funcionario funci)
        {
            MySqlCommand cmd = new MySqlCommand("update TBFuncionario set func_Nome=@func_Nome, func_Tel=@func_Tel, func_Email=@func_Email, func_DataNasc=@func_DataNasc, func_Num_End=@func_Num_End, func_Cargo=@func_Cargo, fk_Cep_cep=@fk_Cep_cep where Func_CPF=@func_Cpf", con.ConectarBD());
            cmd.Parameters.Add("@func_Nome", MySqlDbType.varchar).Value = funci.Func_nome;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.Tel).Value = funci.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.varchar).Value = funci.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.DataNasc).Value = funci.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.int).Value = funci.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.varchar).Value = funci.Func_cargo;
            cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            cmd.DesconectarBD();
        }
        
        public void AltProduto(Classe_Produto produ)
        {
            MySqlCommand cmd = new MySqlCommand("update TBProduto set prod_Nome=@prod_Nome, prod_Tipo=@prod_Tipo, prod_Quant_Estoque=@prod_Quant_Estoque, prod_Desc=@prod_Desc, prod_AnoLanc=@prod_AnoLanc, prod_FaixaEta=@prod_FaixaEta, prod_Valor=@prod_Valor where Cod_pro=@cod_pROD", con.ConectarBD());
            cmd.Parameters.Add("@prod_Nome", MySqlDbType.varchar).Value = produ.Prod_nome;
            cmd.Parameters.Add("@prod_Tipo", MySqlDbType.varchar).Value = produ.Prod_tipo;
            cmd.Parameters.Add("@prod_Quant_Estoque", MySqlDbType.int).Value = produ.Prod_quant_estoque;
            cmd.Parameters.Add("@prod_Desc", MySqlDbType.varchar).Value = produ.Prod_desc;
            cmd.Parameters.Add("@prod_AnoLanc", MySqlDbType.varchar).Value = produ.Prod_anolanc;
            cmd.Parameters.Add("@prod_FaixaEta", MySqlDbType.int).Value = produ.Prod_faixaeta;
            cmd.Parameters.Add("@prod_Valor", MySqlDbType.decimal).Value = produ.Prod_valor;
            cmd.ExecuteNonQuery;
            cmd.DesconectarBD();
        }
        
        //ABAIXO ESTÁ OS MÉTODOS QUE DELETA DAS CLASSES DISPONÍVEIS
        
        public void DelCliente(Classe_Cliente client)
        {
            var deletacl = String.Format("delete from TBCliente where cli_Cpf = {0}", codcl);
            MySqlCommand cmd = new MySqlCommand(deletacl, con.ConectarBD());
            cmd.ExecuteReader();
        }
        
        public void DelFuncionario(Classe_Funcionario funcio)
        {
            var deletafn = String.Format("delete from TBFuncionario where func_Cod = {0}", codfn);
            MySqlCommand cmd = new MySqlCommand(deletafn, con.ConectarBD());
            cmd.ExecuteReader();
        }
        
        public void DelProduto(Classe_Produto produt)
        {
            var deletapd = String.Format("delete from TBProduto where Cod_Prod = {0}", codpd;
            MySqlCommand cmd = new MySqlCommand(deletapd, con.ConectarBD());
            cmd.ExecuteReader();
        }
        
        //INÍCIO DAS CONSULTAS DAS CLASSES DISPONÍVEIS
         
        //Ínicio à Cliente
        //APENAS LISTA OS CLIENTES                                 
        public List<Classe_Cliente> ListarCli()
        {
            MySqlCommand cmd = new MySqlCommand("Select*from TBCliente", con.ConectarBD());
            var dadoscli = cmd.ExecuteReader();
            return ListarCliente(dadoscli);
        }
        
        //MÉTODO PARA LISTAR OS CLIENTES POR CPF

        public Classe_Cliente ListarCliCpf(numeric cpf)
        {
            MySqlCommand cmd = new MySqlCommand("select * from TBCliente where cli_cpf = {0}", cpf, con.ConectarBD());
            cmd.ExecuteReader();
        }
                                         
        //MÉTODO PARA LISTAR TODOS OS CLIENTES DO BD
        public List<Classe_Cliente> ListarCliente(MySqlDataReader dr)                                
        {
            var ListCli = new List <Classe_Cliente>();
            while (dr.Read())
            {
                var CliTemp = new Classe_Cliente()
                {
                    cli_cpf = numeric.Parse(dr["Cli_cpf"].ToString()),
                    cli_Nome = dr["Cli_nome"].ToString(),
                    cli_NumEnd = int.Parse(dr["Cli_numEnd"].ToString()),
                    cli_email = dr["Cli_tel"].ToString(),
                    fk_Cep_cep = dr["Cep"].ToString(),
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
            MySqlCommand cmd = new MySqlCommand("Select*from TBFuncionario", con.ConectarBD());
            var dadosfun = cmd.ExecuteReader();
            return ListarFuncio(dadoscli);
        }
        
        //MÉTODO PARA LISTAR O FUNCIONÁRIO COM SEU COD
        public Classe_Funcionario ListarFuncProd(int cdfun)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from TBFuncionario where func_Cod = {0}", cdfun, con.ConectarBD());
            cmd.ExecuteReader();
        }
                                         
        //MÉTODO PARA LISTAR TODOS OS FUNCIONÁRIOS do bd
        public List<Classe_Funcionario> ListarFuncionario(MySqlDataReader dr)
        {
            var ListFun = new List <Classe_Funcionario>();
            while (dr.Read())
            {
                var FunTemp new Classe_Funcionario()
                {
                    func_Cod = default,
                    func_Nome = dr["Func_nome"].ToString(),
                    func_CPF = numeric.Parse(dr["Func_cpf"].ToString()),
                    func_Tel = numeric.Parse(dr["Func_tel"].ToString()),
                    func_Email = dr["Func_email"].ToString(),
                    func_DataNasc = DateTime.Parse(dr["Func_datanasc"].ToString()),
                    func_Num_End = int.Parse(dr["Func_num_end"].ToString()),
                    func_Cargo = dr["Func_cargo"].ToString()),
                    fk_Cep_cep = dr["Cep"].ToString()),
                };
                ListFun.Add(FunTemp)
            }
            dr.Close();
            return ListFun;
        }
                                         
        //FIM DA CLASSE FUNCIONÁRIO
                                         
        //Ínicio da Classe Produto
        
                                         
        //Apenas O método para listar a classe produtos                                 
        public List<Classe_Produto> ListarProd()
        {
            MySqlCommand cmd = new MySqlCommand("Select*from TBProduto", con.ConectarBD());
            var dadospro = cmd.ExecuteReader();
            return ListarProduto(dadospro);
        }        
        
        //MÉTODO PARA LISTAR OS PRODUTOS COM O CÓDIGO
        public Classe_Produto ListarProdCod(int cdpro)
        {
            MySqlCommand cmd = new MySqlCommand("select*from TBProduto where cod_Prod = {0}", cdpro, con.ConectarBD());
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
                    cod_Prod = int.Parse(dr["Cod_prod"].ToString()),
                    prod_Nome = dr["Prod_nome"].ToString(),
                    prod_Tipo = dr["Prod_tipo"].ToString(),
                    prod_Quant_Estoque = int.Parse(dr["Prod_quant_estoque"],ToString()),
                    prod_Desc = dr["Prod_desc"].ToString(),
                    prod_AnoLanc = dr["Prod_anolanc"].ToString(),
                    prod_FaixaEta = dr["...".ToString(),
                    prod_Valor = decimal.Parse(dr["Prod_valor"].ToString()  
                };
                ListProd.Add(ProdTemp)
            }
            dr.Close();
            return ListProd;
        }
    }
}
