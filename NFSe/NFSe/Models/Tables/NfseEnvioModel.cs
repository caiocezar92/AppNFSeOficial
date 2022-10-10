using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("NFSEENVIO")]
    public class NfseEnvioModel
    {
        /// <summary>
        /// Id NFS-e Envio
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IdRps
        /// </summary>
        public int IdRps { get; set; }

        /// <summary>
        /// Data 
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Status NFS-e
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Erro
        /// </summary>
        public string Erro { get; set; }

        /// <summary>
        /// XML de Envio
        /// </summary>
        public string XmlEnvio { get; set; }

        /// <summary>
        /// ID Url
        /// </summary>
        public int IdUrl { get; set; }
    }
}
