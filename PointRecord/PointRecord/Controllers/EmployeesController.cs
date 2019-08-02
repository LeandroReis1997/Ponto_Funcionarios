using Microsoft.AspNetCore.Mvc;
using PointRecord.Models.Employees;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PointRecord.Controllers
{
    [Route("employees")]
    public class EmployeesController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var employeesRestClient = new EmployeesRestClient();
            var employees = await employeesRestClient.GetAll
            ().Result.Content.ReadAsAsync<List<Employees>>();
            return View(employees);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            var newDate = new Employees();
            newDate.Dateregister = DateTime.Now;
            return View("Add", newDate);
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
            var Employees = await EmployeesRestClient.Find
                (id).Result.Content.ReadAsAsync<Employees>();
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