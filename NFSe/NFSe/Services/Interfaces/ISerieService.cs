using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface ISerieService
  {
    Task<dynamic> CreateSerie(SerieModel serieModel);
    Task<List<SerieModel>> BuscaSeries();
    Task<SerieModel> BuscaSerie(int id);
    Task<dynamic> UpdateSerie(SerieModel serieModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
