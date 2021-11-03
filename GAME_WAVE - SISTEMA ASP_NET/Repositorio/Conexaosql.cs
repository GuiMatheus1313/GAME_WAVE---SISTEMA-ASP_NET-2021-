using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAME_WAVE___SISTEMA_ASP_NET.Repositorio
{
    public class Conexaosql
    {
        MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=BDLojaJogos_tcm;user=root;pwd=guiguiba");
        public static string msg; 
        
        MySqlConnection ConectarBD()
        {
            try
            {            
                conexao.Open();
            }
            catch(Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return conexao
          }
        
        public MySqlConnection DesconectarBD()
        {
            try 
            {
                conexao.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se desconectar" + erro.Message;
            }
            return conexao;
        }
    }
}
