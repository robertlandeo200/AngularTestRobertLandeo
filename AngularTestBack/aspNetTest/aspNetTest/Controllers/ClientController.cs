using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspNetTest.Data;
using aspNetTest.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspNetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _repository;

        public ClientController(ClientRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        public async Task<ActionResult<ResponseClient>> Get()
        {
            ResponseClient oResponse = await _repository.GetAllClient();
            return oResponse;
        }
        [HttpGet("{clientname}")]
        public async Task<ActionResult<ResponseClient>> Get(string clientname)
        {
            ResponseClient oResponse = await _repository.GetByClientName(clientname);

            return oResponse;
        }

        [HttpPost]
        public async Task<ResponseClient> Post([FromBody] ClientCE client)
        {
            ResponseClient oResponse = await _repository.Insert(client);

            return oResponse;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public async Task<ResponseClient> Put([FromBody] ClientCE client)
        {

            ResponseClient oResponse = await _repository.UpdateById(client);
            return oResponse;

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ResponseClient> Delete(int id)
        {
            ResponseClient oResponse = await _repository.DeleteById(id);
            return oResponse;

        }
    }
}
