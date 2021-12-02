using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Funcionario
    {
        public Int16 Func_cod { get; set; }

        public string Func_nome { get; set;}

        private decimal(0,11) Func_cpf { get; set; }

        private decimal(0,11) Func_tel { get; set; }

        private string Func_email { get; set; }

        public string Func_datanasc { get; set; }

        public string Func_cargo { get; set; }

        public string Nome_uf { get; set; }

        public string Nome_cidade { get; set; }

        public string Nome_bairro { get; set; }

        public string Logradouro { get; set; }

        public string Cep { get; set; }

        public Int16 Func_num_end { get; set; }
    }
}
