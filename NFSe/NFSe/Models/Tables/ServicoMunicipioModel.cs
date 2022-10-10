using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CSERVICOMUNICIPIO")]
    public class ServicoMunicipioModel
    {
        /// <summary>
        /// Id  - Serviço Município
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Município - Serviço Município
        /// </summary>
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Id do Serviço Prestado Município
        /// </summary>
        public int IdServico { get; set; }

        /// <summary>
        /// Código do Serviço Município
        /// </summary>
        public string CodigoMunicipal { get; set; }

        /// <summary>
        /// Código do Serviço Federal
        /// </summary>
        public string CodigoFederal { get; set; }
    }
}
