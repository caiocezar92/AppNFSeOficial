using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CCLIENTE")]
    public class ClienteModel
    {
        /// <summary>
        /// Id Cliente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome Cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Nome Fantasia - Cliente
        /// </summary>
        public string NomeFantasia { get; set; }

        /// <summary>
        /// CPF/CNPJ Cliente
        /// </summary>
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Inscrição Estadual - Cliente
        /// </summary>
        public string InscEstadual { get; set; }

        /// <summary>
        /// Inscrição Município - Cliente
        /// </summary>
        public string InscMunicipal { get; set; }
        
        /// <summary>
        /// Id Tipo Logradouro - Cliente 
        /// </summary>
        public int IdTipoLogr { get; set; }

        /// <summary>
        /// Rua Cliente
        /// </summary>
        public string Rua { get; set; }
        
        /// <summary>
        /// Numero Cliente
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento Cliente
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Id Tipo Bairro - Cliente
        /// </summary>
        public int IdTipoBairro { get; set; }

        /// <summary>
        /// Bairro Cliente
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Id Município - Cliente
        /// </summary>
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Cep - Cliente
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Email Cliente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  DDD Cliente
        /// </summary>
        public string Ddd { get; set; }

        /// <summary>
        /// Telefone Cliente
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Cliente Estrangeiro
        /// </summary>
        public bool Estrangeiro { get; set; }

        /// <summary>
        /// Notifica Tomador - Cliente
        /// </summary>
        public bool NotificaToma { get; set; }

         /// <summary>
         /// Tipo Pessoa - Cliente
         /// </summary>
        public string TipoPessoa { get; set; }

        /// <summary>
        /// Chave RM - Cliente
        /// </summary>
        public string ChaveRm { get; set; }

    }
}
