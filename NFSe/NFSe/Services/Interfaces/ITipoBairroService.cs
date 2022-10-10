using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface ITipoBairroService
  {
    Task<dynamic> CreateTipoBairro(TipoBairroModel tipobairroModel);
    Task<List<TipoBairroModel>> BuscaTiposBairro();
    Task<TipoBairroModel> BuscaTipoBairro(int id);
    Task<dynamic> UpdateTipoBairro(TipoBairroModel paisModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
