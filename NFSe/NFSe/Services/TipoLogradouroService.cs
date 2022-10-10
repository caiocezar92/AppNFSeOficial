using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class TipoLogradouroService : ServiceBase, ITipoLogradouroService
  {

    private readonly BaseContext _baseContext;

    public TipoLogradouroService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<TipoLogradouroModel> BuscaTipoLogradouro(int id)
    {

      TipoLogradouroModel tipologradouroModel = _baseContext.CTipoLogradouro.FirstOrDefault(e => e.Id == id);
      return tipologradouroModel;

    }

    public async Task<List<TipoLogradouroModel>> BuscaTiposLogradouro()
    {

      List<TipoLogradouroModel> tipologradouroModel = _baseContext.CTipoLogradouro.ToList();
      return tipologradouroModel;

    }

    public async Task<dynamic> CreateTipoLogradouro(TipoLogradouroModel tipologradouroModel)
    {
      try
      {
        _baseContext.CTipoLogradouro.Add(tipologradouroModel);
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
        TipoLogradouroModel tipologradouroModel = _baseContext.CTipoLogradouro.FirstOrDefault(e => e.Id == id);
        _baseContext.CTipoLogradouro.Remove(tipologradouroModel);
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

    public async Task<dynamic> UpdateTipoLogradouro(TipoLogradouroModel tipologradouroModel)
    {
      try
      {
        _baseContext.CTipoLogradouro.Update(tipologradouroModel);
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
