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
    public class TributoController : ControllerBase
    {


    private readonly ITributoService _tributoService;

    public TributoController(ITributoService tributoService)
    {

      _tributoService = tributoService;

    }

    // GET: api/Tributo
    [HttpGet]
    public async Task<IEnumerable<TributoModel>> Get()
    {
      return await _tributoService.BuscaTributos();
    }

    // GET: api/Tributo/5
    [HttpGet("{id}", Name = "GetTributo")]
    public async Task<TributoModel> Get(int id)
    {
      return await _tributoService.BuscaTributo(id);
    }

    // POST: api/Tributo
    [HttpPost]
    public async Task<dynamic> Post([FromBody] TributoModel tributoModel)
    {

      return await _tributoService.CreateTributo(tributoModel);

    }

    // PUT: api/Tributo/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] TributoModel tributoModel)
    {

      return await _tributoService.UpdateTributo(tributoModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _tributoService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _tributoService.DeleteList(listid);

    }

  }
}