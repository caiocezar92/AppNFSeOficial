using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("NFSENOTAFISCAL")]
    public class NfseNotaFiscalModel
    {
        /// <summary>
        /// Id  - NFSe
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IdRPS  - NFSe
        /// </summary>
        public int IdRps { get; set; }

        /// <summary>
        /// Status  - NFSe
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Status  - NFSe
        /// </summary>
        public DateTime DataStatus { get; set; }

        /// <summary>
        /// XML Rps
        /// </summary>
        public string XmlRps { get; set; }

        /// <summary>
        /// XML Nota
        /// </summary>
        public string XmlNota { get; set; }

        /// <summary>
        /// Código Verificação da NFS-e
        /// </summary>
        public string CodigoVerificacao { get; set; }

        /// <summary>
        /// Chave de Acesso da NFS-e
        /// </summary>
        public string ChaveAcessoNfse { get; set; }
    }
}
