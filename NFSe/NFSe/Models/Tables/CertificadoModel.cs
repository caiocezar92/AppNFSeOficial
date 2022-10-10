using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models
{
    [Table("CCERTIFICADO")]
    public class CertificadoModel
    {
        /// <summary>
        /// Id Certificado
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Cnpj Certificado
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Descrição - Certificado
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Certificado
        /// </summary>
        public string Certificado { get; set;  }

        /// <summary>
        /// Senha Certificado
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Inicio Validade
        /// </summary>
        public DateTime InicioValidade { get; set; }

        /// <summary>
        /// Fim Validade
        /// </summary>
        public DateTime FimValidade { get; set; }

        /// <summary>
        /// Status Certificado
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Certificado Path
        /// </summary>
        [NotMapped]
        public string CertificadoPath { get; set; }
    }
}
