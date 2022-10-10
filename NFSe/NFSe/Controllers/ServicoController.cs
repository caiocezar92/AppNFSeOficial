using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NFSe.Models.Tables;
using NFSe.Services;

namespace NFSe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {


    private readonly IServicoService _servicoService;

    public ServicoController(IServicoService servicoService)
    {

      _servicoService = servicoService;

    }

    // GET: api/Servico
    [HttpGet]
    public async Task<IEnumerable<ServicoModel>> Get()
    {
      return await _servicoService.BuscaServicos();
    }

    // GET: api/Servico/5
    [HttpGet("{id}", Name = "GetServico")]
    public async Task<ServicoModel> Get(int id)
    {
      return await _servicoService.BuscaServico(id);
    }

    // POST: api/Servico
    [HttpPost]
    public async Task<dynamic> Post([FromBody] ServicoModel servicoModel)
    {

      return await _servicoService.CreateServico(servicoModel);

    }

    // PUT: api/Servico/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] ServicoModel servicoModel)
    {

      return await _servicoService.UpdateServico(servicoModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _servicoService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _servicoService.DeleteList(listid);

    }

  }
}