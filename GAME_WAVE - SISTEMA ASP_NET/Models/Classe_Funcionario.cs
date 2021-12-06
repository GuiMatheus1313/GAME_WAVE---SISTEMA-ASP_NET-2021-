using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Funcionario
    {
        public Int16 Func_cod { get; set; }
        
        
        [Display(Name = "Nome do Funcionário")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter o mínimo entre 2 a 50 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Func_nome { get; set;}
        
        [Display(Name = "CPF do Funcionário")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage = "O formato do CPF está incorreto")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo deve conter 14 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Func_cpf { get; set; }
        
        [Display(Name = "Celular do Funcionário")]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do número está incorreto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public long Func_tel { get; set; }
        
        [Display(Name = "Email do Funcionário")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O formato do email está incorreto")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Func_email { get; set; }
        
        [Display(Name = "Data de Nascimento do Funcionário")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
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
        [Display(Name = "Cargo do Funcionário")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "O campo deve conter o mínimo entre 4 a 25 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Func_cargo { get; set; }
        
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
        public Int16 Func_num_end { get; set; }

        [Display(Name = "Senha do Funcionário")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "O campo deve conter o mínimo entre 8 a 30 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Func_senha { get; set; }
    }
}
