using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
  [Table("CESTADO")]
  public class EstadoModel
  {
      /// <summary>
      /// Id Estado
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Nome Estado
      /// </summary>
      public string Nome { get; set; }

      /// <summary>
      /// Código Estado
      /// </summary>
      public string Codigo { get; set; }

      /// <summary>
      /// Id do País - Estado
      /// </summary>
      public int IdPais { get; set; }
  }
}
