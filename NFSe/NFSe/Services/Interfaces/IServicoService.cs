using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IServicoService
  {
    Task<dynamic> CreateServico(ServicoModel servicoModel);
    Task<List<ServicoModel>> BuscaServicos();
    Task<ServicoModel> BuscaServico(int id);
    Task<dynamic> UpdateServico(ServicoModel servicoModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
