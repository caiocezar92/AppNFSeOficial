using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFSe.Services
{
  public class ServiceBase
  {

    public async Task<dynamic> GeraMensagemSucesso(string mensagem = "Cadastro Realizado com Sucesso")
    {
      return new
      {
        erro = false,
        mensagem
      };
    }

    public async Task<dynamic> GeraMensagemErro(string mensagem="Erro no Sistema, contate o Administrado")
    {

      return new
      {
        erro = true,
        mensagem
      };

    }

  }
}
