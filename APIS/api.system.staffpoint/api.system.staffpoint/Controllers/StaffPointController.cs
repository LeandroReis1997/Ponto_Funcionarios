using System;
using System.Collections.Generic;
using System.Net;
using api.system.staffpoint.Models;
using api.system.staffpoint.Repository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.system.staffpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffPointController : Controller
    {
        #region Construtor

        private readonly IStaffpointRepository repository;

        public StaffPointController(IStaffpointRepository repo)
        {
            repository = repo;
        }

        #endregion

        #region Read
        /// <summary>
        /// Retorna todos os registro de pontoes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [Produces(typeof(IEnumerable<StaffPoint>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<StaffPoint>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(StaffPoint))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IEnumerable<StaffPoint> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Retorna um registro de ponto através de seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Find/{id}", Name = "GetStaffPoint")]
        [Produces(typeof(IEnumerable<StaffPoint>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(StaffPoint))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetById(long id)
        {
            var staffPoint = repository.Find(id);
            if (staffPoint == null)
                return NotFound();

            return new ObjectResult(staffPoint);
        }

        #endregion

        #region Create

        /// <summary>
        /// Insere um registro de ponto
        /// </summary>
        /// <param name="staffPoint"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [Produces(typeof(IEnumerable<StaffPoint>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(StaffPoint))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Create([FromBody] StaffPoint staffPoint)
        {
            if (staffPoint == null)
                return BadRequest();

            TimeSpan totalHoras1 = new TimeSpan((staffPoint.EndTime1 - staffPoint.StartTime1).Ticks);
            TimeSpan totalHoras2 = new TimeSpan((staffPoint.EndTime2 - staffPoint.StartTime2).Ticks);

            DateTime t3 = new DateTime((totalHoras1 + totalHoras2).Ticks);

            var getAll = repository.GetAll();
            var hours = new TimeSpan();

            foreach (var item in getAll)
            {
                var tarde = item.EndTime2 - item.StartTime2;
                var manha = item.EndTime1 - item.StartTime1;
                hours += (manha + tarde);
            }

            staffPoint.hours_month = hours.ToString();
            staffPoint.Hoursday = t3.ToShortTimeString().ToString();

            repository.add(staffPoint);

            return CreatedAtRoute("GetStaffPoint", new { id = staffPoint.Id }, staffPoint);
        }

        #endregion

        #region Update
        [HttpPut("Update/{id}")]
        [Produces(typeof(IEnumerable<StaffPoint>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(StaffPoint))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult Update(long id, [FromBody] StaffPoint staffPoint)
        {
            if (staffPoint == null || staffPoint.Id != id)
                return BadRequest();

            var _staffPoint = repository.Find(id);

            if (_staffPoint == null)
                return NotFound();


            _staffPoint.EmployeesId = staffPoint.EmployeesId;
            _staffPoint.DateCurrent = staffPoint.DateCurrent;
            _staffPoint.StartTime1 = staffPoint.StartTime1;
            _staffPoint.StartTime2 = staffPoint.StartTime2;
            _staffPoint.EndTime1 = staffPoint.EndTime1;
            _staffPoint.EndTime2 = staffPoint.EndTime2;

            TimeSpan totalHoras1 = new TimeSpan((_staffPoint.EndTime1 - _staffPoint.StartTime1).Ticks);
            TimeSpan totalHoras2 = new TimeSpan((_staffPoint.EndTime2 - _staffPoint.StartTime2).Ticks);

            DateTime t3 = new DateTime((totalHoras1 + totalHoras2).Ticks);

            _staffPoint.Hoursday = t3.ToShortTimeString().ToString();

            repository.update(_staffPoint);
            return CreatedAtRoute("GetStaffPoint", new { id = staffPoint.Id }, staffPoint);
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
            var staffPoint = repository.Find(id);
            if (staffPoint == null)
                return NotFound();

            repository.remover(id);
            return CreatedAtRoute("GetStaffPoint", new { id = staffPoint.Id }, staffPoint);
        }
        #endregion
    }
}