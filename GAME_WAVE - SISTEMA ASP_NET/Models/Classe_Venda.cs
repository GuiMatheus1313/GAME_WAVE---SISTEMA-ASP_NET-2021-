using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Venda
    {
        [Display(Name = "Código da Venda")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo de venda!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public Int32 Ven_Cod { get; set; }
        
        [Display(Name = "Número de parcelas")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo de parcelas!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public Int16 Parcelas { get; set; }
        
        [Display(Name = "Forma do pagamento")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter a forma de pagamento")]
        [Required(ErrorMessage = "Este campo é obrigatório!")] 
        public string Forma_Pag { get; set; }

        [Display(Name = "Valor total")]
        [StringLength(9, MinimumLength = 1, ErrorMessage = "O campo deve conter o valor total")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public decimal ValorTotal { get; set; }

        [Display(Name = "CPF do Cliente")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato do CPF está incorreto")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo deve conter 14 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Fk_Cliente_Cli_cpf { get; set; }

        [Display(Name = "Código do Cupom")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter o codigo de desconto!")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Fk_Cupom_cupom_cod { get; set; }
    }
}
