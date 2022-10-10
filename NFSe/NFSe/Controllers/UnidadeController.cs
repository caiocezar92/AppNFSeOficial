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
    public class UnidadeController : ControllerBase
    {


    private readonly IUnidadeService _unidadeService;

    public UnidadeController(IUnidadeService unidadeService)
    {

      _unidadeService = unidadeService;

    }

    // GET: api/Unidade
    [HttpGet]
    public async Task<IEnumerable<UnidadeModel>> Get()
    {
      return await _unidadeService.BuscaUnidades();
    }

    // GET: api/Unidade/5
    [HttpGet("{id}", Name = "GetUnidade")]
    public async Task<UnidadeModel> Get(int id)
    {
      return await _unidadeService.BuscaUnidade(id);
    }

    // POST: api/Unidade
    [HttpPost]
    public async Task<dynamic> Post([FromBody] UnidadeModel unidadeModel)
    {

      return await _unidadeService.CreateUnidade(unidadeModel);

    }

    // PUT: api/Unidade/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] UnidadeModel unidadeModel)
    {

      return await _unidadeService.UpdateUnidade(unidadeModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _unidadeService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _unidadeService.DeleteList(listid);

    }

  }
}