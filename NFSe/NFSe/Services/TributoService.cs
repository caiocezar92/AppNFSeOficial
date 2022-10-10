using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class TributoService : ServiceBase, ITributoService
  {

    private readonly BaseContext _baseContext;

    public TributoService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<TributoModel> BuscaTributo(int id)
    {

      TributoModel tributoModel = _baseContext.CTributo.FirstOrDefault(e => e.Id == id);
      return tributoModel;

    }

    public async Task<List<TributoModel>> BuscaTributos()
    {

      List<TributoModel> tributoModel = _baseContext.CTributo.ToList();
      return tributoModel;

    }

    public async Task<dynamic> CreateTributo(TributoModel tributoModel)
    {
      try
      {
        _baseContext.CTributo.Add(tributoModel);
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
        TributoModel tributoModel = _baseContext.CTributo.FirstOrDefault(e => e.Id == id);
        _baseContext.CTributo.Remove(tributoModel);
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

    public async Task<dynamic> UpdateTributo(TributoModel tributoModel)
    {
      try
      {
        _baseContext.CTributo.Update(tributoModel);
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
