using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Servico
    {
        public Int32 Cod_Serv { get; set; }

        public string Desc_Serv { get; set; }

        public string Prod_Serv { get; set; }

        [Display(Name = "Data de Entrada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DateEntre
        {
            get
            {
                return this.dateEntre.HasValue
                    ? this.dateEntre.Value
                    : DateTime.Now;
            }

            set
            {
                this.dateEntre = value;
            }
        }

        private DateTime? dateEntre = null;


        [Display(Name = "Data de Retirada")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DateSaida
        {
            get
            {
                return this.dateSaida.HasValue
                    ? this.dateSaida.Value
                    : DateTime.Now;
            }

            set
            {
                this.dateSaida = value;
            }
        }

        private DateTime? dateSaida = null;


        public float Valor_servico { get; set; }

        public Int32 Fk_Funcionario_Func_Cod { get; set; }
    }
}