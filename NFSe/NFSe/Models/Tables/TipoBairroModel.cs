using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
  [Table("CTIPOBAIRRO")]
  public class TipoBairroModel
  {
      /// <summary>
      /// Id Bairro
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Codigo Bairro
      /// </summary>
      public string Codigo { get; set; }

      /// <summary>
      /// Descrição Bairro
      /// </summary>
      public string Descricao { get; set; }

      /// <summary>
      /// Id Município - Bairro
      /// </summary>
      public int IdMunicipio { get; set; }

  }
}
