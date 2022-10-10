using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IUnidadeService
  {
    Task<dynamic> CreateUnidade(UnidadeModel unidadeModel);
    Task<List<UnidadeModel>> BuscaUnidades();
    Task<UnidadeModel> BuscaUnidade(int id);
    Task<dynamic> UpdateUnidade(UnidadeModel unidadeModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
