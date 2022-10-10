using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class EstadoService : ServiceBase, IEstadoService
  {

    private readonly BaseContext _baseContext;

    public EstadoService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<EstadoModel> BuscaEstado(int id)
    {

      EstadoModel estadoModel = _baseContext.CEstado.FirstOrDefault(e => e.Id == id);
      return estadoModel;

    }

    public async Task<List<EstadoModel>> BuscaEstados()
    {

      List<EstadoModel> estadoModel = _baseContext.CEstado.ToList();
      return estadoModel;

    }

    public async Task<dynamic> CreateEstado(EstadoModel estadoModel)
    {
      try
      {
        _baseContext.CEstado.Add(estadoModel);
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
        EstadoModel estadoModel = _baseContext.CEstado.FirstOrDefault(e => e.Id == id);
        _baseContext.CEstado.Remove(estadoModel);
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

    public async Task<dynamic> UpdateEstado(EstadoModel estadoModel)
    {
      try
      {
        _baseContext.CEstado.Update(estadoModel);
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
