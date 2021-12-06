using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_ItemPedido
    {
        public Int32 Fk_Produto_Cod_Prod__Venda_Ven_Cod { get; set; }

        public Int16 Fk_Produto_Cod_Prod { get; set; }

        public Int32 Fk_Venda_Ven_Cod { get; set; }

        public Int16 Qtn { get; set; }

        public decimal ValorUni { get; set; }

        public decimal total { get; set; }


    }
}