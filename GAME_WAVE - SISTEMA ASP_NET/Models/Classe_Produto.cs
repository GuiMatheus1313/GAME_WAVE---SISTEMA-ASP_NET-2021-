using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Produto
    {
        public Int16 Cod_prod { get; set; }

        public string Prod_nome { get; set; }

        public string Prod_tipo { get; set; }

        public Int16 Prod_quant_estoque { get; set; }

        public string Prod_desc { get; set; }

        public string Prod_anolanc { get; set; }
        
        public string Prod_faixaeta {get; set; }

        public decimal Prod_valor { get; set; }
    }
}
