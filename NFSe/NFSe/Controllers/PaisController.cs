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
    public class PaisController : ControllerBase
    {

        private readonly IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {

          _paisService = paisService;

        }
        // GET: api/Pais
        [HttpGet]
        public async Task<IEnumerable<PaisModel>> Get()
        {
            return await _paisService.BuscaPaises();
        }

        // GET: api/Pais/5
        [HttpGet("{id}", Name = "GetPais")]
        public async Task<PaisModel> Get(int id)
        {
            return await _paisService.BuscaPais(id);
        }

        // POST: api/Pais
        [HttpPost]
        public async Task<dynamic> Post([FromBody] PaisModel paisModel)
        {

          return await _paisService.CreatePais(paisModel); 

        }

        // PUT: api/Pais/5
        [HttpPut("{id}")]
        public async Task<dynamic> Put([FromBody] PaisModel paisModel)
        {

          return await _paisService.UpdatePais(paisModel);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {

          return await _paisService.Delete(id);

        }

        // Delete em lote
        [HttpDelete]
        public async Task<dynamic> Delete([FromBody] List<int> listid)
        {

          return await _paisService.DeleteList(listid);

        }

  }
}
