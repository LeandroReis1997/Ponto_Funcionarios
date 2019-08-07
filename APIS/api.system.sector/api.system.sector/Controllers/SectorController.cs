using api.system.sector.Models;
using api.system.sector.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Net;

namespace api.system.sector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : Controller
    {
        #region Construtor

        private readonly ISectorRepository repository;

        public SectorController(ISectorRepository repo)
        {
            repository = repo;
        }

        #endregion

        #region Read
        /// <summary>
        /// Retorna todos os setores
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [Produces(typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(Sector))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IEnumerable<Sector> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet("GetAllOrderBy")]
        [Produces(typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(Sector))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IEnumerable<Sector> GetAllOrderBy()
        {
            return repository.GetAllOrderBy();
        }

        /// <summary>
        /// Retorna um setor através de seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Find/{id}", Name = "GetSector")]
        [Produces(typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(Sector))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetById(long id)
        {
            var sector = repository.Find(id);
            if (sector == null)
                return NotFound();

            return new ObjectResult(sector);
        }

        #endregion

        #region Create

        /// <summary>
        /// Insere um setor
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [Produces(typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(Sector))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Create([FromBody] Sector sector)
        {
            if (sector == null)
                return BadRequest();

            repository.add(sector);

            return CreatedAtRoute("GetSector", new { id = sector.id }, sector);
        }

        #endregion

        #region Update
        [HttpPut("Update/{id}")]
        [Produces(typeof(IEnumerable<Sector>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(Sector))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Update(long id, [FromBody] Sector sector)
        {
            if (sector == null || sector.id != id)
                return BadRequest();

            var _sector = repository.Find(id);

            if (_sector == null)
                return NotFound();

            _sector.name = sector.name;
            _sector.active = sector.active;

            repository.update(_sector);
            return CreatedAtRoute("GetSector", new { id = sector.id }, sector);
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
            var sector = repository.Find(id);
            if (sector == null)
                return NotFound();

            repository.remover(id);
            return CreatedAtRoute("GetSector", new { id = sector.id }, sector);
        }
        #endregion
    }
}