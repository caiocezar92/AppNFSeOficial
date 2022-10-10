using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface ITipoLogradouroService
  {
    Task<dynamic> CreateTipoLogradouro(TipoLogradouroModel tipologradouroModel);
    Task<List<TipoLogradouroModel>> BuscaTiposLogradouro();
    Task<TipoLogradouroModel> BuscaTipoLogradouro(int id);
    Task<dynamic> UpdateTipoLogradouro(TipoLogradouroModel tipologradouroModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
