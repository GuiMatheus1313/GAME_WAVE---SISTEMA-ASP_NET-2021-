using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Produto
    {
        [Display(Name = "Código do Produto")]
        public Int16 Cod_prod
        { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 50 caracteres")]
        public string Prod_nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Tipo do Produto")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 20 caracteres")]
        public string Prod_tipo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Quantidade em estoque")]
        [Range(1, 9999, ErrorMessage = "O campo deve ter entre 1 a 9999 itens")]
        public Int16 Prod_quant_estoque { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Descrição do produto")]
        [MaxLength(200, ErrorMessage = "O campo contém o máximo de 200 caracteres")]
        public string Prod_desc { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Ano de Lançamento")]
        public string Prod_anolanc { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Faixa etária")]
        [MaxLength(40, ErrorMessage = "O campo contém o máximo de 40 caracteres")]
        public string Prod_faixaeta {get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Valor Unitário")]
        public float Prod_valor { get; set; }
    }
}
