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
    public class LoansController : ControllerBase
    {
        private readonly LoansRepository _repository;

        public LoansController(LoansRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        public async Task<ActionResult<ResponseLoans>> Get()
        {
            ResponseLoans oResponse = await _repository.GetAllLoans();
            return oResponse;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseLoans>> Get(int id)
        {
            ResponseLoans oResponse = await _repository.GetLoansByIdClient(id);

            return oResponse;
        }

        [HttpPost]
        public async Task<ResponseLoans> Post([FromBody] LoansCE loans)
        {
            ResponseLoans oResponse = await _repository.Insert(loans);

            return oResponse;
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public async Task<ResponseLoans> Put([FromBody] LoansCE loans)
        {

            ResponseLoans oResponse = await _repository.UpdateById(loans);
            return oResponse;

        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ResponseLoans> Delete(int id)
        {
            ResponseLoans oResponse = await _repository.DeleteById(id);
            return oResponse;

        }
    }
}
