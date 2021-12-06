using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GAME_WAVE___SISTEMA_ASP_NET.Models
{
    public class Classe_Delivery
    {
        public Int32 Deli_Cod { get; set; }

        [Display(Name = "Data de Saída")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY 00:00}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime Deli_Data
        {
            get
            {
                return this.deli_Data.HasValue
                    ? this.deli_Data.Value
                    : DateTime.Now;
            }
            set
            {
                this.deli_Data = value;
            }
        }
        private DateTime? deli_Data = null;


        public string Fk_Cliente_Cli_cpf { get; set; }

        public Int32 Fk_Venda_Ven_Cid { get; set; }
    }
}