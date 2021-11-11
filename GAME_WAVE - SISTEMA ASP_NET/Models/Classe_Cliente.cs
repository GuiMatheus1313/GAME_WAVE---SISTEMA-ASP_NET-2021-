using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Cliente
    {
        private long Cli_cpf { get; set; }

        public string Cli_nome { get; set; }

        public DateTime Cli_datanasc { get; set; }

        private string Cli_email { get; set; }

        private long Cli_tel { get; set; }

        public string Nome_uf { get; set; }

        public string Nome_cidade { get; set; }

        public string Nome_bairro { get; set; }

        public string Logradouro { get; set; }

        public string Cep { get; set; }

        public Int16 Cli_numEnd { get; set; }
    }
}