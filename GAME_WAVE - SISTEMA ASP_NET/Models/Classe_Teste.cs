using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Teste
    {
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Código do agendamento")]
        public int Agen_Cod { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Data de retirada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        public DateTime Age_DtRetirada
        {
            get
            {
                return this.age_DtRetirada.HasValue
                    ? this.age_DtRetirada.Value
                    : DateTime.Now;
            }

            set
            {
                this.age_DtRetirada = value;
            }
        }
        private DateTime? age_DtRetirada = null;

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Descrição do agendamento")]
        [StringLength(120, MinimumLength = 10, ErrorMessage = "O campo deve conter 10 a 120 caracteres")]
        public string Age_Desc { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "CPF do Cliente")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato está incorreto")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo deve conter 14 caracteres")]
        public string Fk_Cliente_Cli_cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Display(Name = "Código do produto")]
        public int Fk_Produto_Cod_Prod { get; set; }
    }
}
