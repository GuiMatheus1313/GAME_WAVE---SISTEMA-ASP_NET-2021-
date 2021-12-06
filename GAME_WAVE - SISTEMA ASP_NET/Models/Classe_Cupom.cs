using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Cupom
    {
        [Display(Name = "Código do Cupom")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo de desconto!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Cupom_cod { get; set; }
        
        [Display(Name = "Cupom de Desconto")]
        [StringLength(2, MinimumLength = 5, ErrorMessage = "O campo deve conter o valor de desconto!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public float DescontoCupom { get; set; }
    }
}
