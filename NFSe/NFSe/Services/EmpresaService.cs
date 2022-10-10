using Microsoft.AspNetCore.Authentication;
using NFSe.Context;
using NFSe.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class EmpresaService : ServiceBase, IEmpresaService
  {

    private readonly BaseContext _baseContext;

    public EmpresaService(BaseContext baseContext)
    {

      _baseContext = baseContext;

    }

    public async Task<EmpresaModel> BuscaEmpresa(int id)
    {

        EmpresaModel empresaModel = _baseContext.CEmpresa.FirstOrDefault(e => e.Id == id);
        return empresaModel;

    }

    public async Task<List<EmpresaModel>> BuscaEmpresas()
    {

      List<EmpresaModel> empresaModel = _baseContext.CEmpresa.ToList();
      return empresaModel;

    }

    public async Task<dynamic> CreateEmpresa(EmpresaModel empresaModel)
    {
      try
      {
        _baseContext.CEmpresa.Add(empresaModel);
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
        EmpresaModel empresaModel = _baseContext.CEmpresa.FirstOrDefault(e => e.Id == id);
        _baseContext.CEmpresa.Remove(empresaModel);
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


    public async Task<dynamic> UpdateEmpresa(EmpresaModel empresaModel)
    {
      try
      {
        _baseContext.CEmpresa.Update(empresaModel);
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
