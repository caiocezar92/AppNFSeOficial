using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
  [Table("CTIPOLOGR")]
  public class TipoLogradouroModel
  {
      /// <summary>
      /// Id Logradouro
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Codigo Logradouro
      /// </summary>
      public string Codigo { get; set; }

      /// <summary>
      /// Descrição Logradouro
      /// </summary>
      public string Descricao { get; set; }

      /// <summary>
      /// Id Município - Tipo Logradouro
      /// </summary>
      public int IdMunicipio { get; set; }
  }
}
