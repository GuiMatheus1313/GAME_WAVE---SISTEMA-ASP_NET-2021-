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
            cmd.Parameters.Add("@prod_Desc", MySqlDbType.varchar).Value = prod.Prod_nome;




        }

    }
}
