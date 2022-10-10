using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IFilialService
  {
    Task<dynamic> CreateFilial(FilialModel filialModel);
    Task<List<FilialModel>> BuscaFiliais();
    Task<FilialModel> BuscaFilial(int id);
    Task<dynamic> UpdateFilial(FilialModel filialModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
