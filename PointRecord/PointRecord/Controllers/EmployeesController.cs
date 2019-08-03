using Microsoft.AspNetCore.Mvc;
using PointRecord.Models.Employees;
using PointRecord.Models.Sector;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PointRecord.Controllers
{
    [Route("employees")]
    public class EmployeesController : Controller
    {
        //[Route("")]
        //[Route("~/")]
        //[Route("index")]
        public async Task<IActionResult> Index()
        {
            var employeesRestClient = new EmployeesRestClient();
            var employees = await employeesRestClient.GetAll
            ().Result.Content.ReadAsAsync<List<Employees>>();
            return View(employees);
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Add()
        {
            var sectorRestClient = new SectorsRestClient();
            var employees = new Employees();
            ViewBag.sector = "Cadastre um novo setor no sistema...";
            employees.Dateregister = DateTime.Now;
            employees.Sector = await sectorRestClient.GetAllOrderBy
            ().Result.Content.ReadAsAsync<List<Sectors>>();
            return View("Add", employees);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Employees Employees)
        {
            var EmployeesRestClient = new EmployeesRestClient();
            var create = await EmployeesRestClient.Create(Employees);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(long id)
        {
            var EmployeesRestClient = new EmployeesRestClient();
            var sector = new SectorsRestClient();
            var Employees = await EmployeesRestClient.Find
                (id).Result.Content.ReadAsAsync<Employees>();
            Employees.Sector = await sector.GetAllOrderBy().Result.Content.ReadAsAsync<List<Sectors>>();
            return View("Edit", Employees);
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(long id, Employees Employees)
        {
            var EmployeesRestClient = new EmployeesRestClient();
            var update = await EmployeesRestClient.Update(id, Employees);
            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var EmployeesRestClient = new EmployeesRestClient();
            var delete = await EmployeesRestClient.Delete(id);
            return RedirectToAction("Index");
        }
    }
}