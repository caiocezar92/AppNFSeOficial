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
    public class MunicipioController : ControllerBase
    {

        private readonly IMunicipioService _municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {

          _municipioService = municipioService;

        }
        // GET: api/Municipio
        [HttpGet]
        public async Task<IEnumerable<MunicipioModel>> Get()
        {
            return await _municipioService.BuscaMunicipios();
        }

        // GET: api/Municipio/5
        [HttpGet("{id}", Name = "GetMunicipio")]
        public async Task<MunicipioModel> Get(int id)
        {
            return await _municipioService.BuscaMunicipio(id);
        }

        // POST: api/Municipio
        [HttpPost]
        public async Task<dynamic> Post([FromBody] MunicipioModel municipioModel)
        {

          return await _municipioService.CreateMunicipio(municipioModel); 

        }

        // PUT: api/Municipio/5
        [HttpPut("{id}")]
        public async Task<dynamic> Put([FromBody] MunicipioModel municipioModel)
        {

          return await _municipioService.UpdateMunicipio(municipioModel);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {

          return await _municipioService.Delete(id);

        }

        // Delete em lote
        [HttpDelete]
        public async Task<dynamic> Delete([FromBody] List<int> listid)
        {

          return await _municipioService.DeleteList(listid);

        }

  }
}
