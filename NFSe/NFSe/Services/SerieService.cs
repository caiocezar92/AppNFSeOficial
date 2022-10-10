using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class SerieService : ServiceBase, ISerieService
  {

    private readonly BaseContext _baseContext;

    public SerieService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<SerieModel> BuscaSerie(int id)
    {

      SerieModel serieModel = _baseContext.CSerie.FirstOrDefault(e => e.Id == id);
      return serieModel;

    }

    public async Task<List<SerieModel>> BuscaSeries()
    {

      List<SerieModel> serieModel = _baseContext.CSerie.ToList();
      return serieModel;

    }

    public async Task<dynamic> CreateSerie(SerieModel serieModel)
    {
      try
      {
        _baseContext.CSerie.Add(serieModel);
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
        SerieModel serieModel = _baseContext.CSerie.FirstOrDefault(e => e.Id == id);
        _baseContext.CSerie.Remove(serieModel);
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

    public async Task<dynamic> UpdateSerie(SerieModel serieModel)
    {
      try
      {
        _baseContext.CSerie.Update(serieModel);
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
