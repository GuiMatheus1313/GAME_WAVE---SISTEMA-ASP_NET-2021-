using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Funcionario
    {
        [Display(Name = "Código do Funcionário")]
        public Int16 Func_cod { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 50 caracteres")]
        public string Func_nome { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo deve conter 14 caracteres")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato está incorreto")]
        public string Func_cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Celular")]
        public long Func_tel { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O formato está incorreto")]
        public string Func_email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Func_datanasc 
        {
            get
            {
                return this.func_datanasc.HasValue
                    ? this.func_datanasc.Value
                    : DateTime.Now;
            }
            
            set
            {
                this.func_datanasc = value;
            }
        }
        
            private DateTime? func_datanasc = null;

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Cargo")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "O campo deve conter entre 4 a 25 caracteres")]
        public string Func_cargo { get; set; }

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
        [Display(Name = "Logradouro")]
        [MaxLength(100, ErrorMessage = "O campo deve conter o máximo de 100 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "CEP")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O formato está incorreto")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Número do Logradouro")]
        public Int16 Func_num_end { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Senha para o Funcionário")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "O campo deve conter entre 8 a 30 caracteres")]
        public string Func_senha { get; set; }

        public string FK_cep_cep { get; set; 
        }
    }
}
