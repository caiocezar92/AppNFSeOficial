using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CSERIE")]
    public class SerieModel
    {
        /// <summary>
        /// Id Série
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Filial = Série
        /// </summary>
        public int IdFilial { get; set; }

        /// <summary>
        /// Código Série
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Descrição Série
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Último Numero Série
        /// </summary>
        public string UltNumero { get; set; }
    }
}
