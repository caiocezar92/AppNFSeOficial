using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class ClienteService : ServiceBase, IClienteService
  {

    private readonly BaseContext _baseContext;

    public ClienteService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<ClienteModel> BuscaCliente(int id)
    {

      ClienteModel clienteModel = _baseContext.CCliente.FirstOrDefault(e => e.Id == id);
      return clienteModel;

    }

    public async Task<List<ClienteModel>> BuscaClientes()
    {

      List<ClienteModel> clienteModel = _baseContext.CCliente.ToList();
      return clienteModel;

    }

    public async Task<dynamic> CreateCliente(ClienteModel clienteModel)
    {
      try
      {
        _baseContext.CCliente.Add(clienteModel);
        _baseContext.SaveChanges();

        return GeraMensagemSucesso();
      }
      catch (Exception e)
      {
        return GeraMensagemErro(e.Message);
      }

    }

    public async Task<dynamic> Delete(int id)
    {
      try
      {
        ClienteModel clienteModel = _baseContext.CCliente.FirstOrDefault(e => e.Id == id);
        _baseContext.CCliente.Remove(clienteModel);
        _baseContext.SaveChanges();

        return GeraMensagemSucesso();
      }
      catch (Exception e)
      {
        return GeraMensagemErro(e.Message);
      }

    }

    public async Task<dynamic> DeleteList(List<int> listid)
    {
      try
      {
        foreach (int row in listid)
        {
          Delete(row);
        }
        return GeraMensagemSucesso("Registro deletado com sucesso");
      }
      catch (Exception e)
      {
        return GeraMensagemErro(e.Message);
      }

    }

    public async Task<dynamic> UpdateCliente(ClienteModel clienteModel)
    {
      try
      {
        _baseContext.CCliente.Update(clienteModel);
        _baseContext.SaveChanges();

        return GeraMensagemSucesso();
      }
      catch (Exception e)
      {
        return GeraMensagemErro(e.Message);
      }

    }

  }
}
