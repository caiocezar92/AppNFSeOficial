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
    public class SerieController : ControllerBase
    {


    private readonly ISerieService _serieService;

    public SerieController(ISerieService serieService)
    {

      _serieService = serieService;

    }

    // GET: api/Serie
    [HttpGet]
    public async Task<IEnumerable<SerieModel>> Get()
    {
      return await _serieService.BuscaSeries();
    }

    // GET: api/Serie/5
    [HttpGet("{id}", Name = "GetSerie")]
    public async Task<SerieModel> Get(int id)
    {
      return await _serieService.BuscaSerie(id);
    }

    // POST: api/Serie
    [HttpPost]
    public async Task<dynamic> Post([FromBody] SerieModel serieModel)
    {

      return await _serieService.CreateSerie(serieModel);

    }

    // PUT: api/Serie/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] SerieModel serieModel)
    {

      return await _serieService.UpdateSerie(serieModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _serieService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _serieService.DeleteList(listid);

    }

  }
}