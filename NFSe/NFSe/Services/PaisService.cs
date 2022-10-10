using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class PaisService : ServiceBase, IPaisService
  {

    private readonly BaseContext _baseContext;

    public PaisService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<PaisModel> BuscaPais(int id)
    {

        PaisModel paisModel = _baseContext.CPais.FirstOrDefault(e => e.Id == id);
        return paisModel;

    }

    public async Task<List<PaisModel>> BuscaPaises()
    {

      List<PaisModel> paisModel = _baseContext.CPais.ToList();
      return paisModel;

    }

    public async Task<dynamic> CreatePais(PaisModel paisModel)
    {
      try
      {
        _baseContext.CPais.Add(paisModel);
        _baseContext.SaveChanges();

        return GeraMensagemSucesso();
      }
      catch(Exception e)
      {
        return GeraMensagemErro(e.Message);
      }

    }

    public async Task<dynamic> Delete(int id)
    {
      try
      {
        PaisModel paisModel = _baseContext.CPais.FirstOrDefault(e => e.Id == id);
        _baseContext.CPais.Remove(paisModel);
        _baseContext.SaveChanges();

        return GeraMensagemSucesso();
      }
      catch(Exception e)
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

    public async Task<dynamic> UpdatePais(PaisModel paisModel)
    {
      try
      {
        _baseContext.CPais.Update(paisModel);
        _baseContext.SaveChanges();

        return GeraMensagemSucesso();
      }
      catch(Exception e)
      {
        return GeraMensagemErro(e.Message);
      }

    }
  }
}
