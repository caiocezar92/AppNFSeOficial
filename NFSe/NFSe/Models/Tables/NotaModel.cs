using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models
{
    [Table("NFSERPS")]
    public class NotaModel
    {
        /// <summary>
        /// Id Nota
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data e Hora de Emissão
        /// </summary>
        public DateTime DataHoraEmissao { get; set; } 
        
        /// <summary>
        /// ID Série
        /// </summary>
        public int IdSerie { get; set; } //?? ver com o kids

        /// <summary>
        /// Numero RPS
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Tipo RPS
        /// </summary>
        public int TipoRps { get; set; }

        /// <summary>
        /// Situação RPS
        /// </summary>
        public int SituacaoRps { get; set; }

        /// <summary>
        /// Tipo Recolhimento
        /// </summary>
        public int TipoRecolhimento { get; set; }

        /// <summary>
        /// Tipo Operação
        /// </summary>
        public int TipoOperacao { get; set; }

        /// <summary>
        /// Tipo Tributação
        /// </summary>
        public int TipoTrib { get; set; }

        /// <summary>
        /// Local Serviço
        /// </summary>
        public bool TrbLocalServ { get; set; }

        /// <summary>
        /// ISS Município Prestador
        /// </summary>
        public bool IssMunPrestador { get; set; }

        /// <summary>
        /// ID Municipio Prestador
        /// </summary>
        public int IdMunPrest { get; set; }

        /// <summary>
        /// Id Município Inc
        /// </summary>
        public int IdMunInc { get; set; }

        /// <summary>
        /// Id da Filial
        /// </summary>
        public int IdFilial { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Observação
        /// </summary>
        public string Observacao { get; set; }

        /// <summary>
        /// Chave RM - Notas
        /// </summary>
        public string ChaveRm { get; set; }
    }
}
