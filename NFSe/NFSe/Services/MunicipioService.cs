using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class MunicipioService : ServiceBase, IMunicipioService
  {

    private readonly BaseContext _baseContext;

    public MunicipioService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<MunicipioModel> BuscaMunicipio(int id)
    {

        MunicipioModel municipioModel = _baseContext.CMunicipio.FirstOrDefault(e => e.Id == id);
        return municipioModel;

    }

    public async Task<List<MunicipioModel>> BuscaMunicipios()
    {

      List<MunicipioModel> municipioModel = _baseContext.CMunicipio.ToList();
      return municipioModel;

    }

    public async Task<dynamic> CreateMunicipio(MunicipioModel municipioModel)
    {
      try
      {
        _baseContext.CMunicipio.Add(municipioModel);
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
        MunicipioModel municipioModel = _baseContext.CMunicipio.FirstOrDefault(e => e.Id == id);
        _baseContext.CMunicipio.Remove(municipioModel);
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

    public async Task<dynamic> UpdateMunicipio(MunicipioModel municipioModel)
    {
      try
      {
        _baseContext.CMunicipio.Update(municipioModel);
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
