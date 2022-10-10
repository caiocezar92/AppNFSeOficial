using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class UnidadeService : ServiceBase, IUnidadeService
  {

    private readonly BaseContext _baseContext;

    public UnidadeService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<UnidadeModel> BuscaUnidade(int id)
    {

      UnidadeModel unidadeModel = _baseContext.CUnidade.FirstOrDefault(e => e.Id == id);
      return unidadeModel;

    }

    public async Task<List<UnidadeModel>> BuscaUnidades()
    {

      List<UnidadeModel> unidadeModel = _baseContext.CUnidade.ToList();
      return unidadeModel;

    }

    public async Task<dynamic> CreateUnidade(UnidadeModel unidadeModel)
    {
      try
      {
        _baseContext.CUnidade.Add(unidadeModel);
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
        UnidadeModel unidadeModel = _baseContext.CUnidade.FirstOrDefault(e => e.Id == id);
        _baseContext.CUnidade.Remove(unidadeModel);
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

    public async Task<dynamic> UpdateUnidade(UnidadeModel unidadeModel)
    {
      try
      {
        _baseContext.CUnidade.Update(unidadeModel);
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
