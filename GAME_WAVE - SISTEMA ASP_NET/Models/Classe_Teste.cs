using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Teste
    {
        public Int16 Agen_Cod { get; set; }

        [Display(Name = "Data de Retirada")]
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


        public string Age_Desc { get; set; }

        public string Fk_Cliente_Cli_cpf { get; set; }

        public Int32 Fk_Produto_Cod_Prod { get; set; }
    }
}