using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IPaisService
  {
    Task<dynamic> CreatePais(PaisModel paisModel);
    Task<List<PaisModel>> BuscaPaises();
    Task<PaisModel> BuscaPais(int id);
    Task<dynamic> UpdatePais(PaisModel paisModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
