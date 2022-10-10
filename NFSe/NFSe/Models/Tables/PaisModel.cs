using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
  [Table("CPAIS")]
  public class PaisModel
  {
      /// <summary>
      /// Id País
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Nome País
      /// </summary>
      public string Nome { get; set; }

      /// <summary>
      /// Código País
      /// </summary>
      public string Codigo { get; set; }
  }
}
