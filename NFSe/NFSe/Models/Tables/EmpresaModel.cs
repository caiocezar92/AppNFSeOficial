using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CEMPRESA")]
    public class EmpresaModel
    {
        /// <summary>
        /// Id Empresa
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome Empresa
        /// </summary>
        public string Nome { get; set; }
        
        /// <summary>
        /// Nome Fantasia Empresa
        /// </summary>
        public string NomeFantasia { get; set; }

        /// <summary>
        ///  Chave RM - Empresas
        /// </summary>
        public string ChaveRm { get; set; }
    }
}
