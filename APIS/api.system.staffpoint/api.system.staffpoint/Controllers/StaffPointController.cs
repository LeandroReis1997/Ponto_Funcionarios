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

            TimeSpan totalHoras1 = new TimeSpan((staffPoint.end_time1 - staffPoint.start_time1).Ticks);
            TimeSpan totalHoras2 = new TimeSpan((staffPoint.end_time2 - staffPoint.start_time2).Ticks);

            DateTime t3 = new DateTime((totalHoras1 + totalHoras2).Ticks);

            var getAll = repository.GetAll();
            var hours = new TimeSpan();

            foreach (var item in getAll)
            {
                var tarde = item.end_time2 - item.start_time2;
                var manha = item.end_time1 - item.start_time1;
                hours += (manha + tarde);
            }

            staffPoint.hours_month = hours.ToString();
            staffPoint.hours_day = t3.ToShortTimeString().ToString();

            repository.add(staffPoint);

            return CreatedAtRoute("GetStaffPoint", new { id = staffPoint.id }, staffPoint);
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
            if (staffPoint == null || staffPoint.id != id)
                return BadRequest();

            var _staffPoint = repository.Find(id);

            if (_staffPoint == null)
                return NotFound();


            _staffPoint.employeesid = staffPoint.employeesid;
            _staffPoint.date_current = staffPoint.date_current;
            _staffPoint.start_time1 = staffPoint.start_time1;
            _staffPoint.start_time2 = staffPoint.start_time2;
            _staffPoint.end_time1 = staffPoint.end_time1;
            _staffPoint.end_time2 = staffPoint.end_time2;

            TimeSpan totalHoras1 = new TimeSpan((_staffPoint.end_time1 - _staffPoint.start_time1).Ticks);
            TimeSpan totalHoras2 = new TimeSpan((_staffPoint.end_time2 - _staffPoint.start_time2).Ticks);

            DateTime t3 = new DateTime((totalHoras1 + totalHoras2).Ticks);

            _staffPoint.hours_day = t3.ToShortTimeString().ToString();

            repository.update(_staffPoint);
            return CreatedAtRoute("GetStaffPoint", new { id = staffPoint.id }, staffPoint);
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
            return CreatedAtRoute("GetStaffPoint", new { id = staffPoint.id }, staffPoint);
        }
        #endregion
    }
}