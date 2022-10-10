using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public interface IClienteService
  {
    Task<dynamic> CreateCliente(ClienteModel clienteModel);
    Task<List<ClienteModel>> BuscaClientes();
    Task<ClienteModel> BuscaCliente(int id);
    Task<dynamic> UpdateCliente(ClienteModel clienteModel);
    Task<dynamic> Delete(int id);
    Task<dynamic> DeleteList(List<int> id);

  }
}
