using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IEmpresaService
  {
    Task<dynamic> CreateEmpresa(EmpresaModel empresaModel);
    Task<List<EmpresaModel>> BuscaEmpresas();
    Task<EmpresaModel> BuscaEmpresa(int id);
    Task<dynamic> UpdateEmpresa(EmpresaModel empresaModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
