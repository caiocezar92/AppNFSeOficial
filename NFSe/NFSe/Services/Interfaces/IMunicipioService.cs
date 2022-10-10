using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IMunicipioService
  {
    Task<dynamic> CreateMunicipio(MunicipioModel municipioModel);
    Task<List<MunicipioModel>> BuscaMunicipios();
    Task<MunicipioModel> BuscaMunicipio(int id);
    Task<dynamic> UpdateMunicipio(MunicipioModel municipioModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
