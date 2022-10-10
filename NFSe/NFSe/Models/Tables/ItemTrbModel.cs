using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("NFSERPSITEMTRIB")]
    public class ItemTrbModel
    {
        /// <summary>
        /// Id ItemTrb
        /// </summary>
        public int Id { get; set; }        
        
        /// <summary>
        /// Id Item Tributo
        /// </summary>
        public int IdItem { get; set; }

        /// <summary>
        /// Id Tributo Item
        /// </summary>
        public int IdTributo { get; set; }

        /// <summary>
        /// Base de Cálculo Item
        /// </summary>
        public decimal BaseDeCalculo { get; set; }

        /// <summary>
        /// Aliquota do Item
        /// </summary>
        public decimal Aliquota { get; set; }

        /// <summary>
        /// Valor do Item
        /// </summary>
        public decimal Valor { get; set; }

         /// <summary>
        /// Código Recolhimento Item
        /// </summary>
        public int CodRecolhimento { get; set; }
    }
}
