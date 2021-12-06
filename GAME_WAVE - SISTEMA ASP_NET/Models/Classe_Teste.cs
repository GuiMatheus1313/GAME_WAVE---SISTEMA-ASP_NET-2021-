using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Teste
    {
        [Display(Name = "Código de agendamento")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo de agendamento!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public Int16 Agen_Cod { get; set; }

        [Display(Name = "Data de retirada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
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

        [Display(Name = "Descrição do agendamento")]
        [StringLength(120, MinimumLength = 10, ErrorMessage = "O campo deve conter a descrição!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Age_Desc { get; set; }

        [Display(Name = "CPF do Cliente")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato do CPF está incorreto")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo deve conter 14 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Fk_Cliente_Cli_cpf { get; set; }

        [Display(Name = "Código do produto")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo do produto!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public Int32 Fk_Produto_Cod_Prod { get; set; }
    }
}
