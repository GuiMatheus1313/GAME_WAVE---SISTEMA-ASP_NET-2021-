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
            cmd.Parameters.Add("@func_Nome", MySQLDbType.varchar).Value = funci.Func_nome;
            cmd.Parameters.Add("@func_Tel", MySQLDbType.Tel).Value = funci.Func_tel;
            cmd.Parameters.Add("@func_Email", MySQLDbType.varchar).Value = funci.Func_email;
            cmd.Parameters.Add("@func_DataNasc", MySQLDbType.DataNasc).Value = funci.Func_datanasc;
            cmd.Parameters.Add("@func_Num_End", MySQLDbType.int).Value = funci.Func_num_end;
            cmd.Parameters.Add("@func_Cargo", MySQLDbType.varchar).Value = funci.Func_cargo;
            cmd.Parameters.Add("@fk_Cep_cep", MySqlDbType.int).Value = ;
            cmd.ExecuteNonqQuery();
            cmd.Desconectar();
        }
        
        public void AltProduto(Classe_Produto produ)
        {
            MySqlCommand cmd = new MySqlCommand("update TBProduto set prod_Nome=@prod_Nome, prod_Tipo=@prod_Tipo, prod_Quant_Estoque=@prod_Quant_Estoque, prod_Desc=@prod_Desc, prod_AnoLanc=@prod_AnoLanc, prod_FaixaEta=@prod_FaixaEta, prod_Valor=@prod_Valor where Cod_pro=@
        }

    }
}
