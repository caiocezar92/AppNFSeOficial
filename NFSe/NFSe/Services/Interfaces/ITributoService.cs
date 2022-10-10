using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface ITributoService
  {
    Task<dynamic> CreateTributo(TributoModel tributoModel);
    Task<List<TributoModel>> BuscaTributos();
    Task<TributoModel> BuscaTributo(int id);
    Task<dynamic> UpdateTributo(TributoModel tributoModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
