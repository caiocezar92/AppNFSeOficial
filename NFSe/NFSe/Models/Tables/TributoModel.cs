using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CTRIBUTO")]
    public class TributoModel
    {
        /// <summary>
        /// Id Tributo
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Código Tributo
        /// </summary>
        public string CodTributo { get; set; }

        /// <summary>
        /// Aliquota Tributo
        /// </summary>
        public decimal Aliquota  { get; set; }

        /// <summary>
        /// Recolhimento Tributo
        /// </summary>
        public int CodRecolhimento { get; set; }
    }
}
