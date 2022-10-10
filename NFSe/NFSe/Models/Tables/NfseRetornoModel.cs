using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("NFSERETORNO")]
    public class NfseRetornoModel
    {
        /// <summary>
        /// Id  - NFSe Retorno
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IdEnvio  - NFSe Retorno
        /// </summary>
        public int IdEnvio { get; set; }

        /// <summary>
        /// IdRps  - NFSe Retorno
        /// </summary>
        public int IdRps { get; set; }

        /// <summary>
        /// Data - NFSe Retorno
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Status - NFSe Retorno
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Erro - NFSe Retorno
        /// </summary>
        public string Erro { get; set; }

        /// <summary>
        ///  XML Retorno - NFSe Retorno
        /// </summary>
        public string XmlRetorno {get; set;}
    }
}
