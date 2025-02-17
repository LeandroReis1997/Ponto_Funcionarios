﻿using Microsoft.AspNetCore.Mvc;
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
        #region Read
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var employeesRestClient = new EmployeesRestClient();
            var employees = await employeesRestClient.GetAll
            ().Result.Content.ReadAsAsync<List<Employeees>>();
            return View(employees);
        }

        [HttpPost("index")]
        public async Task<IActionResult> Index(string name)
        {
            var employeesRestClient = new EmployeesRestClient();
            var employees = await employeesRestClient.FindName(name)
            .Result.Content.ReadAsAsync<List<Employeees>>();

            if (employees == null)
                return RedirectToAction("Index");

            return View(employees);
        }
        #endregion

        #region Create
        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Add()
        {
            var sectorRestClient = new SectorsRestClient();
            var employees = new Employeees();
            ViewBag.sector = "Cadastre um novo setor no sistema...";
            employees.dateregister = DateTime.Now;
            employees.Sector = await sectorRestClient.GetAllOrderBy
            ().Result.Content.ReadAsAsync<List<Sectors>>();
            return View("Add", employees);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Employeees employees)
        {
            var employeesRestClient = new EmployeesRestClient();
            var create = await employeesRestClient.Create(employees);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(long id)
        {
            var employeesRestClient = new EmployeesRestClient();
            var sector = new SectorsRestClient();
            ViewBag.sector = "Atualize os setores do sistema...";
            var employees = await employeesRestClient.Find
                (id).Result.Content.ReadAsAsync<Employeees>();
            employees.Sector = await sector.GetAllOrderBy().Result.Content.ReadAsAsync<List<Sectors>>();
            return View("Edit", employees);
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(long id, Employeees employees)
        {
            var EmployeesRestClient = new EmployeesRestClient();
            var update = await EmployeesRestClient.Update(id, employees);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var EmployeesRestClient = new EmployeesRestClient();
            var delete = await EmployeesRestClient.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}