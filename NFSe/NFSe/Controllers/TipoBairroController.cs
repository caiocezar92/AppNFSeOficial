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
    public class TipoBairroController : ControllerBase
    {

        private readonly ITipoBairroService _tipobairroService;

        public TipoBairroController(ITipoBairroService tipobairroService)
        {

          _tipobairroService = tipobairroService;

        }

        // GET: api/TipoBairro
        [HttpGet]
        public async Task<IEnumerable<TipoBairroModel>> Get()
        {
            return await _tipobairroService.BuscaTiposBairro();
        }

        // GET: api/TipoBairro/5
        [HttpGet("{id}", Name = "GetTipoBairro")]
        public async Task<TipoBairroModel> Get(int id)
        {
            return await _tipobairroService.BuscaTipoBairro(id);
        }

        // POST: api/TipoBairro
        [HttpPost]
        public async Task<dynamic> Post([FromBody] TipoBairroModel tipobairroModel)
        {

          return await _tipobairroService.CreateTipoBairro(tipobairroModel); 

        }

        // PUT: api/TipoBairro/5
        [HttpPut("{id}")]
        public async Task<dynamic> Put([FromBody] TipoBairroModel tipobairroModel)
        {

          return await _tipobairroService.UpdateTipoBairro(tipobairroModel);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {

          return await _tipobairroService.Delete(id);

        }

        // Delete em lote
        [HttpDelete]
        public async Task<dynamic> Delete([FromBody] List<int> listid)
        {

          return await _tipobairroService.DeleteList(listid);

        }

  }
}
