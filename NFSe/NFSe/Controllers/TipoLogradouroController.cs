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
    public class TipoLogradouroController : ControllerBase
    {


    private readonly ITipoLogradouroService _tipologradouroService;

    public TipoLogradouroController(ITipoLogradouroService tipologradouroService)
    {

      _tipologradouroService = tipologradouroService;

    }

    // GET: api/TipoLogradouro
    [HttpGet]
    public async Task<IEnumerable<TipoLogradouroModel>> Get()
    {
      return await _tipologradouroService.BuscaTiposLogradouro();
    }

    // GET: api/TipoLogradouro/5
    [HttpGet("{id}", Name = "GetTipoLogradouro")]
    public async Task<TipoLogradouroModel> Get(int id)
    {
      return await _tipologradouroService.BuscaTipoLogradouro(id);
    }

    // POST: api/TipoLogradouro
    [HttpPost]
    public async Task<dynamic> Post([FromBody] TipoLogradouroModel tipologradouroModel)
    {

      return await _tipologradouroService.CreateTipoLogradouro(tipologradouroModel);

    }

    // PUT: api/TipoLogradouro/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] TipoLogradouroModel tipologradouroModel)
    {

      return await _tipologradouroService.UpdateTipoLogradouro(tipologradouroModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _tipologradouroService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _tipologradouroService.DeleteList(listid);

    }

  }
}