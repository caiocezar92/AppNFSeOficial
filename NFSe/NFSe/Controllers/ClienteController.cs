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
    public class ClienteController : ControllerBase
    {


    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {

      _clienteService = clienteService;

    }

    // GET: api/Cliente
    [HttpGet]
    public async Task<IEnumerable<ClienteModel>> Get()
    {
      return await _clienteService.BuscaClientes();
    }

    // GET: api/Cliente/5
    [HttpGet("{id}", Name = "GetCliente")]
    public async Task<ClienteModel> Get(int id)
    {
      return await _clienteService.BuscaCliente(id);
    }

    // POST: api/Cliente
    [HttpPost]
    public async Task<dynamic> Post([FromBody] ClienteModel clienteModel)
    {

      return await _clienteService.CreateCliente(clienteModel);

    }

    // PUT: api/Cliente/5
    [HttpPut("{id}")]
    public async Task<dynamic> Put([FromBody] ClienteModel clienteModel)
    {

      return await _clienteService.UpdateCliente(clienteModel);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {

      return await _clienteService.Delete(id);

    }

    // Delete em lote
    [HttpDelete]
    public async Task<dynamic> Delete([FromBody] List<int> listid)
    {

      return await _clienteService.DeleteList(listid);

    }

  }
}