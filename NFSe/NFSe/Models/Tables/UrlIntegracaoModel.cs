using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CURLINTEGRACAO")]
    public class UrlIntegracaoModel
    {
        /// <summary>
        /// Id Url Integração
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Orgão
        /// </summary>
        public string Orgao { get; set; }

        /// <summary>
        /// Ambiente
        /// </summary>
        public int Ambiente { get; set; }

        /// <summary>
        /// Modelo
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Serviço Integração
        /// </summary>
        public string Servico { get; set; }

        /// <summary>
        /// Url Integração
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Versão Integração
        /// </summary>
        public string Versao { get; set; }
    }
}
