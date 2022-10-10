using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class ServicoService : ServiceBase, IServicoService
  {

    private readonly BaseContext _baseContext;

    public ServicoService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<ServicoModel> BuscaServico(int id)
    {

      ServicoModel servicoModel = _baseContext.CServico.FirstOrDefault(e => e.Id == id);
      return servicoModel;

    }

    public async Task<List<ServicoModel>> BuscaServicos()
    {

      List<ServicoModel> servicoModel = _baseContext.CServico.ToList();
      return servicoModel;

    }

    public async Task<dynamic> CreateServico(ServicoModel servicoModel)
    {
      try
      {
        _baseContext.CServico.Add(servicoModel);
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
        ServicoModel servicoModel = _baseContext.CServico.FirstOrDefault(e => e.Id == id);
        _baseContext.CServico.Remove(servicoModel);
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

    public async Task<dynamic> UpdateServico(ServicoModel servicoModel)
    {
      try
      {
        _baseContext.CServico.Update(servicoModel);
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
