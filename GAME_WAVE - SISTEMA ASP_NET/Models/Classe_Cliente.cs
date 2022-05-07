using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Cliente
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo deve conter 14 caracteres")]
        //[RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato está incorreto")]
        public string Cli_cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 50 caracteres")]
        public string Cli_nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O formato está incorreto")]
        public string Cli_email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Celular")]
        public long Cli_tel { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "UF")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo apenas contém 2 caracteres")]
        public string Nome_uf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Cidade")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 30 caracteres")]
        public string Nome_cidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Bairro")]
        [MinLength(3, ErrorMessage = "O campo deve conter o mínimo de 3 caracteres")]
        public string Nome_bairro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Endereço")]
        [MaxLength(100, ErrorMessage = "O campo deve conter o máximo de 100 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "CEP")]
        //[RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O formato está incorreto")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Número")]
        public Int16 Cli_numEnd { get; set; }

        public string FK_cep_cep { get; set; }

   
    }

}
