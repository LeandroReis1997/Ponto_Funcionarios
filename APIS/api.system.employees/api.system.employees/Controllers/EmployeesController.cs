using System.Collections.Generic;
using System.Net;
using api.system.employees.Models;
using api.system.employees.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.system.employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        #region Construtor
        private readonly IEmployeesRepository repository;

        public EmployeesController(IEmployeesRepository repo)
        {
            repository = repo;
        }
        #endregion

        #region Read

        [HttpGet("GetAll")]
        [Produces(typeof(IEnumerable<Employees>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<Employees>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(Employees))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IEnumerable<Employees> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet("Find/{id}", Name = "GetEmployees")]
        [Produces(typeof(IEnumerable<Employees>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(Employees))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetById(long id)
        {
            var employee = repository.Find(id);
            if (employee == null)
                NotFound();

            return new ObjectResult(employee);
        }
        #endregion

        #region Create

        [HttpPost("Create")]
        [Produces(typeof(IEnumerable<Employees>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(Employees))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Create([FromBody] Employees employees)
        {
            if (employees == null)
                return BadRequest();

            repository.add(employees);

            return CreatedAtRoute("GetEmployees", new { id = employees.id }, employees);
        }
        #endregion

        #region Update

        [HttpPut("Update/{id}")]
        [Produces(typeof(IEnumerable<Employees>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(Employees))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Update(long id, [FromBody] Employees employees)
        {
            if (employees == null || employees.id != id)
                return BadRequest();

            var _employees = repository.Find(id);

            if (_employees == null)
                return NotFound();

            _employees.name = employees.name;
            _employees.cpf = employees.cpf;
            _employees.cep = employees.cep;
            _employees.telephone = employees.telephone;
            _employees.address = employees.address;
            _employees.city = employees.city;
            _employees.state = employees.state;
            _employees.neighborhood = employees.neighborhood;
            _employees.datebirth = employees.datebirth;
            _employees.dateregister = employees.dateregister;
            _employees.sectorId = employees.sectorId;

            repository.update(_employees);
            return CreatedAtRoute("GetEmployees", new { id = employees.id }, employees);
        }
        #endregion

        #region Delete

        [HttpDelete("Delete/{id}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Delete(long id)
        {
            var employee = repository.Find(id);
            if (employee == null)
                return NotFound();

            repository.remove(id);
            return CreatedAtRoute("GetEmployees", new { id = employee.id }, employee);
        }
        #endregion
    }
}