using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Servico
    {
        [Display(Name = "Código do Serviço")]

        public Int32 Cod_Serv { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Descrição do Serviço")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 100 caracteres")]
        public string Desc_Serv { get; set; }

        [Display(Name = "Produto do Serviço")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo deve conter entre 2 a 50 caracteres")]
        public string Prod_Serv { get; set; } 

        [Display(Name = "Data de Entrada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DateEntre
        {
            get{return this.DateEntre = DateTime.Today.Date;}

            set
            {}
        }

        [Display(Name = "Data de Retirada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DateSaida{get; set;}


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Valor do Serviço")]
        public float Valor_servico { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Código do Funcionário")]
        public Int32 Fk_Funcionario_Func_Cod { get; set; }
    }
}