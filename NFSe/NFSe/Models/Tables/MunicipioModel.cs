using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFSe.Models.Tables
{
  [Table("CMUNICIPIO")]
  public class MunicipioModel
  {
      /// <summary>
      /// Id Município
      /// </summary>
      public int Id { get; set; }

      /// <summary>
      /// Código IBGE
      /// </summary>
      public string CodigoIbge { get; set; }

      /// <summary>
      /// Id Etd
      /// </summary>
      public int IdEtd { get; set; }

      /// <summary>
      /// Nome Município
      /// </summary>
      public string Nome { get; set; }
  }
}
