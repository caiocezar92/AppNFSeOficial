using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IEstadoService
  {
    Task<dynamic> CreateEstado(EstadoModel estadoModel);
    Task<List<EstadoModel>> BuscaEstados();
    Task<EstadoModel> BuscaEstado(int id);
    Task<dynamic> UpdateEstado(EstadoModel estadoModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
