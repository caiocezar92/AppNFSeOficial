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
    public class FilialController : ControllerBase
    {


    private readonly IFilialService _filialService;

    public FilialController(IFilialService filialService)
    {

      _filialService = filialService;

    }

    // GET: api/Filial
    [HttpGet]
    public async Task<IEnumerable<FilialModel>> Get()
    {
      return await _filialService.BuscaFiliais();
    }

    // GET: api/Filial/5
    [HttpGet("{id}", Name = "GetFilial")]
    public async Task<FilialModel> Get(int id)
    {
      return await _filialService.BuscaFilial(id);
    }

    // POST: api/Filial
    [HttpPost]
    public async Task<dynamic> Post([FromBody] FilialModel filialModel)
    {

      return await _filialService.CreateFilial(filialModel);

    }

    // PUT: api/Filial/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] FilialModel filialModel)
    {

      return await _filialService.UpdateFilial(filialModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _filialService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _filialService.DeleteList(listid);

    }

  }
}