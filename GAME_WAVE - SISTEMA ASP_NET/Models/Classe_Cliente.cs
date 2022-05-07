using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Cliente
    {
        [Display(Name = "CPF do Cliente")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato do CPF está incorreto")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo deve conter 14 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cli_cpf { get; set; }

        [Display(Name = "Nome do Cliente")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter o mínimo entre 2 a 50 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cli_nome { get; set; }

        [Display(Name = "Email do Cliente")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O formato do email está incorreto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cli_email { get; set; }


        [Display(Name = "Celular do Cliente")]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do número está incorreto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public long Cli_tel { get; set; }

        [Display(Name = "UF")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo apenas contém 2 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome_uf { get; set; }
        
        [Display(Name = "Cidade")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo deve conter o mínimo entre 2 a 30 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome_cidade { get; set; }
        
         [Display(Name = "Bairro")]
        [MinLength(3, ErrorMessage = "O campo deve conter o mínimo de 3 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome_bairro { get; set; }
        
        [Display(Name = "Logradouro do Funcionário")]
        [MaxLength(100, ErrorMessage = "O campo deve conter o máximo de 100 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Logradouro { get; set; }
        
        [Display(Name = "CEP do Funcionário")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O formato do CEP está incorreto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cep { get; set; }
        
        [Display(Name = "Número do Longradouro")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public Int16 Cli_numEnd { get; set; }
    }
}
