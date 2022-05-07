using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Cupom
    {
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Código do Cupom")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "O campo deve conter entre 1 a 12 caracteres")]
        public string Cupom_cod { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Quantidade de Desconto")]
        public float DescontoCupom { get; set; }
    }
}
