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
    public class EstadoController : ControllerBase
    {

        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {

          _estadoService = estadoService;

        }

        // GET: api/Estado
        [HttpGet]
        public async Task<IEnumerable<EstadoModel>> Get()
        {
            return await _estadoService.BuscaEstados();
        }

        // GET: api/Estado/5
        [HttpGet("{id}", Name = "GetEstado")]
        public async Task<EstadoModel> Get(int id)
        {
            return await _estadoService.BuscaEstado(id);
        }

        // POST: api/Estado
        [HttpPost]
        public async Task<dynamic> Post([FromBody] EstadoModel estadoModel)
        {

          return await _estadoService.CreateEstado(estadoModel); 

        }

        // PUT: api/Estado/5
        [HttpPut("{id}")]
        public async Task<dynamic> Put([FromBody] EstadoModel estadoModel)
        {

          return await _estadoService.UpdateEstado(estadoModel);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {

          return await _estadoService.Delete(id);

        }

        // Delete em lote
         [HttpDelete]
         public async Task<dynamic> Delete([FromBody] List<int> listid)
         {

            return await _estadoService.DeleteList(listid);

         }

  }
}
