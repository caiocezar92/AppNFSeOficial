using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models
{
    [Table("NFSERPSITEM")]
    public class ItemNotaModel
    {
        /// <summary>
        /// Id Item Nota
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id RPS Item 
        /// </summary>
        public int IdRps { get; set; }

        /// <summary>
        /// ID Serviço Item
        /// </summary>
        public int IdServico { get; set; }
        
         /// <summary>
         /// Descrição Item
         /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Quantidade Item
        /// </summary>
        public decimal Quantidade { get; set; }

        /// <summary>
        /// Valor Unitário Item
        /// </summary>
        public decimal ValUnitario { get; set; }
        
        /// <summary>
        /// Valor Total Item
        /// </summary>
        public decimal ValTotal { get; set; }

        /// <summary>
        /// Valor Líquido Item
        /// </summary>
        public decimal ValLiquido { get; set; }

        /// <summary>
        /// Valor Deduções Item
        /// </summary>
        public decimal ValDeducoes { get; set; }
        
        /// <summary>
        /// Desconto Condicional Item
        /// </summary>
        public decimal DescCond { get; set; }

        /// <summary>
        /// Desconto Incondicional Item
        /// </summary>
        public decimal DescIncond { get; set; }

        /// <summary>
        /// Valor Carga Tributária Item
        /// </summary>
        public decimal ValCargaTrib { get; set; }

        /// <summary>
        /// Valor Percentual Carga Tributária Item
        /// </summary>
        public decimal ValPerCargaTrib { get; set; }
        
         /// <summary>
         /// Fonte Carga Tributária Item
         /// </summary>
        public string FonteCargaTrib { get; set; }

         /// <summary>
         /// Outras Despesas Item
         /// </summary>
        public decimal OutrasDesp { get; set; }

    }
}
