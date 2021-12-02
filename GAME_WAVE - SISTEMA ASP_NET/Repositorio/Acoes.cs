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

        /* Incompleto BD, esperando a revisão da análise */
        
        public void CadastrarCliente(Classe_Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBCliente values(@cli_Cpf,@cli_Nome,@cli_NumEnd,@cli_Email,@cli_Tel)", conectar.ConectarBD());
            cmd.Parameters.Add("@cli_Cpf", MySqlDbType.decimal).Value = cli.Cli_cpf;
            cmd.Parameters.Add("@cli_Nome", MySqlDbType.VarChar).Value = cli.Cli_nome;
            cmd.Parameters.Add("@cli_NumEnd", MySqlDbType.Int32).Value = cli.Cli_numEnd;
            cmd.Parameters.Add("@cli_Email", MySqlDbType.VarChar).Value = cli.Cli_email;
            cmd.Parameters.Add("@cli_Tel", MySqlDbType.decimal).Value = cli.Cli_tel;
            /*cmd.Parameters.Add("@fk_fidelidade_Brinde_cod", MySqlDbType.int).Value = ;
            cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            */
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        
        public void CadastrarFuncio(Classe_Funcionario fun)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBFuncionario values(default,@func_Nome,@func_CPF,@func_Tel,@func_Email,@func_DataNasc,@func_Num_End,@func_Cargo)", conectar.ConectarBD());
            cmd.Parameters.Add("@func_Nome", MySqlDbType.VarChar).Value = fun.Func_nome;
            cmd.Parameters.Add("@func_CPF", MySqlDbType.decimal).Value = fun.Func_cpf;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.decimal).Value = fun.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.VarChar).Value = fun.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.DateTime).Value = fun.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.Int32).Value = fun.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.VarChar).Value = fun.Func_cargp;
            //cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.varchar).Value = fun.Cep;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        public void CadastroProduto(Classe_Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("insert into TBProduto values(default,@prod_Nome,@prod_Tipo,@prod_Quant_Estoque,@prod_Desc,@prod_AnoLanc,@prod_FaixaEta,@prod_Valor)", conectar.ConectarBD());
            cmd.Parameters.Add("@prod_Nome", MySqlDbType.VarChar).Value = prod.Prod_nome;
            cmd.Parameters.Add("@prod_Tipo", MySqlDbType.VarChar).Value = prod.Prod_tipo;
            cmd.Parameters.Add("@prod_Quant_Estoque", MySqlDbType.Int32).Value = prod.Prod_quant_estoque;
            cmd.Parameters.Add("@prod_Desc", MySqlDbType.VarChar).Value = prod.Prod_desc;
            cmd.Parameters.Add("@prod_AnoLanc", MySqlDbType.VarChar).Value = prod.Prod_anolanc;
            cmd.Parameters.Add("@prod_FaixaEta", MySqlDbType.VarChar).Value = prod.Prod_faixaeta;
            cmd.Parameters.Add("@prod_Valor", MySqlDbType.decimal).Value = prod.Prod_valor;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }

        
        
        //ABAIXO ESTÁ OS MÉTODOS DE ALTERAÇÕES DAS CLASSES DISPONÍVEIS
        
        public void AltCliente(Classe_Cliente clien)
        {
            MySqlCommand cmd = new MySqlCommand("update TBCliente set cli_Nome=@cli_Nome, cli_NumEnd=@cli_NumEnd, cli_Tel=@cli_Tel where Cli_cpf=@cli_Cpf", conectar.ConectarBD());
            cmd.Parameters.Add("@cli_Nome", MySqlDbType.decimal).Value = clien.Cli_nome;
            cmd.Parameters.Add("@cli_NumEnd", MySqlDbType.Int32).Value = clien.Cli_numEnd;
            cmd.Parameters.Add("@cli_Tel", MySqlDbType.decimal).Value = clien.Cli_tel;
            //cmd.Parameters.Add("@fk_fidelidade_Brinde_cod", MySqlDbType.int).Value = ;
            //cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonQuery();
            conectar.DesconectarBD();
        }
        
        
        public void AltFuncio(Classe_Funcionario funci)
        {
            MySqlCommand cmd = new MySqlCommand("update TBFuncionario set func_Nome=@func_Nome, func_Tel=@func_Tel, func_Email=@func_Email, func_DataNasc=@func_DataNasc, func_Num_End=@func_Num_End, func_Cargo=@func_Cargo where Func_CPF=@func_Cpf", conectar.ConectarBD());
            cmd.Parameters.Add("@func_Nome", MySqlDbType.VarChar).Value = funci.Func_nome;
            cmd.Parameters.Add("@func_Tel", MySqlDbType.decimal).Value = funci.Func_tel;
            cmd.Parameters.Add("@func_Email", MySqlDbType.VarChar).Value = funci.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySqlDbType.DateTime).Value = funci.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySqlDbType.Int16).Value = funci.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySqlDbType.VarChar).Value = funci.Func_cargo;
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
            cmd.Parameters.Add("@prod_Valor", MySqlDbType.decimal).Value = produ.Prod_valor;
            cmd.ExecuteNonQuery;
            cmd.DesconectarBD();
        }
        
        
        //ABAIXO ESTÁ OS MÉTODOS QUE DELETA DAS CLASSES DISPONÍVEIS
        
        public void DelCliente(Classe_Cliente clientcpf)
        {
            var deletacl = String.Format("delete from TBCliente where cli_Cpf = {0}", clientcpf);
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
            var deletapd = String.Format("delete from TBProduto where Cod_Prod = {0}", produtcod;
            MySqlCommand cmd = new MySqlCommand(deletapd, conectar.ConectarBD());
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

        public Classe_Cliente ListarCliCpf(decimal cpf)
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
                    Cli_cpf = decimal.Parse(dr["Cli_cpf"].ToString()),
                    Cli_nome = dr["Cli_nome"].ToString(),
                    Cli_numEnd = Int16.Parse(dr["Cli_numEnd"].ToString()),
                    Cli_email = dr["Cli_email"].ToString(),
                    Cli_tel = decimal.Parse(dr["Cli_tel"].ToString()),
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
            MySqlCommand cmd = new MySqlCommand("Select*from TBFuncionario", con.ConectarBD());
            var dadosfun = cmd.ExecuteReader();
            return ListarFuncionario(dadosfun);
        }
        
        //MÉTODO PARA LISTAR O FUNCIONÁRIO COM SEU COD
        public Classe_Funcionario ListarFuncProd(int cdfun)
        {
            var comando = String.Format("Select * from TBFuncionario where func_Cod = {0}". cdfun)
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
                var FunTemp new Classe_Funcionario()
                {
                    Func_Cod = default,
                    Func_nome = dr["Func_nome"].ToString(),
                    Func_cpf = decimal.Parse(dr["Func_cpf"].ToString()),
                    Func_tel = decimal.Parse(dr["Func_tel"].ToString()),
                    Func_email = dr["Func_email"].ToString(),
                    Func_datanasc = DateTime.Parse(dr["Func_datanasc"].ToString()),
                    Func_num_end = Int16.Parse(dr["Func_num_end"].ToString()),
                    Func_cargo = dr["Func_cargo"].ToString(),
                    //fk_Cep_cep = dr["Cep"].ToString()),
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
                    Cod_Prod = default,
                    Prod_nome = dr["Prod_nome"].ToString(),
                    Prod_tipo = dr["Prod_tipo"].ToString(),
                    Prod_quant_estoque = Int32.Parse(dr["Prod_quant_estoque"],ToString()),
                    Prod_desc = dr["Prod_desc"].ToString(),
                    Prod_anolanc = dr["Prod_anolanc"].ToString(),
                    Prod_faixaeta = dr["Prod_faixaeta".ToString(),
                    Prod_valor = decimal.Parse(dr["Prod_valor"].ToString()),
                };
                ListProd.Add(ProdTemp)
            }
            dr.Close();
            return ListProd;
        }
        
    }
}
