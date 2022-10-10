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
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {

          _empresaService = empresaService;

        }
        // GET: api/Empresa
        [HttpGet]
        public async Task<IEnumerable<EmpresaModel>> Get()
        {
            return await _empresaService.BuscaEmpresas();
        }

        // GET: api/Empresa/5
        [HttpGet("{id}", Name = "GetEmpresa")]
        public async Task<EmpresaModel> Get(int id)
        {
            return await _empresaService.BuscaEmpresa(id);
        }

        // POST: api/Empresa
        [HttpPost]
        public async Task<dynamic> Post([FromBody] EmpresaModel empresaModel)
        {

          return await _empresaService.CreateEmpresa(empresaModel); 

        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public async Task<dynamic> Put([FromBody] EmpresaModel empresaModel)
        {

          return await _empresaService.UpdateEmpresa(empresaModel);

        }

    
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {

          return await _empresaService.Delete(id);

        }

        // Delete em lote
        [HttpDelete]
        public async Task<dynamic> Delete([FromBody] List<int> listid)
        {
          
          return await _empresaService.DeleteList(listid);

        }

    }
}
