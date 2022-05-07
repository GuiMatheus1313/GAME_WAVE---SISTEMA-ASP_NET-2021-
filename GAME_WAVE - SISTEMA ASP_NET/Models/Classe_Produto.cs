using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Produto
    {
        public Int16 Cod_prod { get; set; }

        [Display(Name = "Nome do Produto")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter o mínimo entre 2 a 50 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Prod_nome { get; set; }

        [Display(Name = "Tipo do Produto")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo deve conter o mínimo entre 2 a 20 caracteres")]
        public string Prod_tipo { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Range(1, 9999, ErrorMessage = "A quantidade de estoque deve ter no mínimo entre 1 a 9999 produtos")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Int16 Prod_quant_estoque { get; set; }

        [Display(Name = "Descrição do produto")]
        [MaxLength(200, ErrorMessage = "O campo contém o máximo de 200 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Prod_desc { get; set; }

        [Display(Name = "Ano de Lançamento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Prod_anolanc { get; set; }
        
        [Display(Name = "Faixa etária do Produto")]
        [MaxLength(40, ErrorMessage = "O campo contém o máximo de 40 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Prod_faixaeta {get; set; }

        [Display(Name = "Valor Unitário do Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Prod_valor { get; set; }
    }
}
