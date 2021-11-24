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
            MySqlCommand cmd = new MySqlCommand("insert into Cliente values(@cli_cpf,@cli_nome,@cli_numend,@cli_email,@cli_tel,@fk_fidelidade_brinde_cod,@fk_cep_cep)", con.ConectarBD());
            cmd.Parameters.Add("@cli_cpf", MySqlDbType.numeric).Value = cli.Cli_cpf;
            cmd.Parameters.Add("@cli_nome", MySqlDbType.varchar).Value = cli.Cli_Nome;
            cmd.Parameters.Add("@cli_numend", MySqlDbType.int).Value = cli.Cli_numEnd;
            cmd.Parameters.Add("@cli_email", MySqlDbType.varchar).Value = cli.Cli_email;
            cmd.Parameters.Add("@cli_tel", MySqlDbType.numeric).Value = cli.Cli_tel;
            cmd.Parameters.Add("@flarchar).Value = cli.Cli_Nome;




        }

    }
}
