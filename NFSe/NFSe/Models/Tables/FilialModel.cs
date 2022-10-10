using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
    [Table("CFILIAL")]
    public class FilialModel
    {
        /// <summary>
        /// Id Filial
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome Filial
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Nome Fantasia Filial
        /// </summary>
        public string NomeFantasia { get; set; }

        /// <summary>
        /// Id Empresa
        /// </summary>
        public int IdEmpresa { get; set; }

        /// <summary>
        /// Cnpj Filial
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição Estadual Filial
        /// </summary>
        public string InscEstadual { get; set; }

        /// <summary>
        /// Inscrição Municipal Filial
        /// </summary>
        public string InscMunicipal { get; set; }

        /// <summary>
        /// CNAE Filial
        /// </summary>
        public string Cnae { get; set; }

        /// <summary>
        /// Id Municipio
        /// </summary>
        public int IdMunicipio { get; set; }

        /// <summary>
        /// Email Filial
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// DDD Filial
        /// </summary>
        public string Ddd { get; set; }

        /// <summary>
        /// Telefone Filial
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// Optante Simples
        /// </summary>
        public bool OptanteSimples { get; set; }

        /// <summary>
        /// Incentivo Cultural
        /// </summary>
        public bool IncentCultural { get; set; }

        /// <summary>
        /// Id Tipo Logradouro Filial
        /// </summary>
        public int IdTipoLogr { get; set; }

        /// <summary>
        /// Rua Filial
        /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// Numero Endereço Filial
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Numero Endereço Filial
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Id Tipo Bairro Filial
        /// </summary>
        public int IdTipoBairro { get; set; }

        /// <summary>
        /// Bairro Filial
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Cep Filial
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Chave RM Filial
        /// </summary>
        public string ChaveRm { get; set; }
    }
}
