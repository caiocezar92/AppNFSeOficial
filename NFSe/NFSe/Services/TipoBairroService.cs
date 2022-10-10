using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class TipoBairroService : ServiceBase, ITipoBairroService
  {

    private readonly BaseContext _baseContext;

    public TipoBairroService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<TipoBairroModel> BuscaTipoBairro(int id)
    {

      TipoBairroModel tipobairroModel = _baseContext.CTipoBairro.FirstOrDefault(e => e.Id == id);
      return tipobairroModel;

    }

    public async Task<List<TipoBairroModel>> BuscaTiposBairro()
    {

      List<TipoBairroModel> tipobairroModel = _baseContext.CTipoBairro.ToList();
      return tipobairroModel;

    }

    public async Task<dynamic> CreateTipoBairro(TipoBairroModel tipobairroModel)
    {
      try
      {
        _baseContext.CTipoBairro.Add(tipobairroModel);
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
        TipoBairroModel tipobairroModel = _baseContext.CTipoBairro.FirstOrDefault(e => e.Id == id);
        _baseContext.CTipoBairro.Remove(tipobairroModel);
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

    public async Task<dynamic> UpdateTipoBairro(TipoBairroModel tipobairroModel)
    {
      try
      {
        _baseContext.CTipoBairro.Update(tipobairroModel);
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
