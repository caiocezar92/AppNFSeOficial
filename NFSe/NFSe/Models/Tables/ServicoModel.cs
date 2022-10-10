using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CSERVICO")]
    public class ServicoModel
    {
        /// <summary>
        /// Id Serviço
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome Serviço
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição Serviço
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Id Unidade Serviço
        /// </summary>
        public int IdUnidade { get; set; }
    }
}
