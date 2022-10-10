using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CUNIDADE")]
    public class UnidadeModel
    {
        /// <summary>
        /// Id Unidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Código Unidade
        /// </summary>
        public string CodUnidade { get; set; }
    }
}
