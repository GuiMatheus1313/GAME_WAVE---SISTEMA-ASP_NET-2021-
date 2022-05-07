using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_ItemPedido
    {
        [Display(Name = "Numero do pedido")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo deve conter o mínimo entre 1 e 5 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Int32 Fk_Produto_Cod_Prod__Venda_Ven_Cod { get; set; }

        [Display(Name = "Código do produto")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo do produto!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public Int16 Fk_Produto_Cod_Prod { get; set; }

        [Display(Name = "código da venda")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo deve conter o código da venda")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Int32 Fk_Venda_Ven_Cod { get; set; }

        [Display(Name = "Quantidade")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo deve conter o mínimo entre 1 e 5 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Int16 Qtd { get; set; } 

        [Display(Name = "Valor unitário")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo deve conter o mínimo entre 1 e 5 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal ValorUni { get; set; }

        [Display(Name = "Total")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O campo deve conter o mínimo entre 1 e 5 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal total { get; set; }


    }
}
