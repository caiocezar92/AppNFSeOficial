using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class FilialService : ServiceBase, IFilialService
  {

    private readonly BaseContext _baseContext;

    public FilialService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<FilialModel> BuscaFilial(int id)
    {

      FilialModel filialModel = _baseContext.CFilial.FirstOrDefault(e => e.Id == id);
      return filialModel;

    }

    public async Task<List<FilialModel>> BuscaFiliais()
    {

      List<FilialModel> filialModel = _baseContext.CFilial.ToList();
      return filialModel;

    }

    public async Task<dynamic> CreateFilial(FilialModel filialModel)
    {
      try
      {
        _baseContext.CFilial.Add(filialModel);
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
        FilialModel filialModel = _baseContext.CFilial.FirstOrDefault(e => e.Id == id);
        _baseContext.CFilial.Remove(filialModel);
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

    public async Task<dynamic> UpdateFilial(FilialModel filialModel)
    {
      try
      {
        _baseContext.CFilial.Update(filialModel);
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
