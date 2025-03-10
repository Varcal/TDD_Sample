﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TDD_Sample.Api.Models;
using TDD_Sample.Dados.Repositorios;
using TDD_Sample.Dominio.Entidades;
using TDD_Sample.Dominio.Servicos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDD_Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IClienteServico _clienteServico;

        public ClienteController(IUnitOfWork unitOfWork, IClienteServico clienteServico)
        {
            _unitOfWork = unitOfWork;
            _clienteServico = clienteServico;
        }


        //// GET: api/<ClienteController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ClienteController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteRequest request)
        {
            var cliente = await _clienteServico.RegistrarAsync(new Cliente(request.Nome, request.Cpf, request.Email, request.DataNascimento));
            var retorno = await _unitOfWork.SaveChangesAsync();

            if (retorno <= 0) return BadRequest();

            return Created("Created", cliente);
        }

        //// PUT api/<ClienteController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ClienteController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
