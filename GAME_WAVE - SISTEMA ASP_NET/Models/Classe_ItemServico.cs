using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_ItemServico
    {
        public Int32 Fk_Servico_Cod_Serv { get; set; }

        public Int32 Fk_Venda_Ven_Cod { get; set; }
    }
}