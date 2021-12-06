using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Venda
    {
        public Int32 Ven_Cod { get; set; }
        
        public Int16 Parcelas { get; set; }
        
        public string Forma_Pag { get; set; }

        public decimal ValorTotal { get; set; }

        public string Fk_Cliente_Cli_cpf { get; set; }

        public string Fk_Cupom_cupom_cod { get; set; }
    }
}