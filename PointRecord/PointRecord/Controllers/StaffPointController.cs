﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PointRecord.Models.Employees;
using PointRecord.Models.StaffPoint;

namespace PointRecord.Controllers
{
    [Route("staffpoint")]
    public class StaffPointController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var staffpointRestClient = new StaffPointRestiClient();
            var staffpoint = await staffpointRestClient.GetAll
            ().Result.Content.ReadAsAsync<List<StaffPoint>>();
            return View(staffpoint);
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Add()
        {
            var employeesRestClient = new EmployeesRestClient();
            var staffpoint = new StaffPoint();
            ViewBag.employee = "Cadastre um novo funcionário no sistema...";
            staffpoint.DateCurrent = AddBusinessDays(DateTime.Now, 1);
            staffpoint.StartTime1 = DateTime.Now;
            staffpoint.EmployeesList = await employeesRestClient.GetAll
            ().Result.Content.ReadAsAsync<List<Employeees>>();
            return View("Add", staffpoint);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(StaffPoint staffPoint)
        {
            var staffpointRestClient = new StaffPointRestiClient();
            var create = await staffpointRestClient.Create(staffPoint);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(long id)
        {
            var Date = new StaffPoint();
            var staffpointRestClient = new StaffPointRestiClient();
            var employees = new EmployeesRestClient();
            var staffpoint = await staffpointRestClient.Find
                (id).Result.Content.ReadAsAsync<StaffPoint>();
            staffpoint.EmployeesList = await employees.GetAll().Result.Content.ReadAsAsync<List<Employeees>>();
            return View("Edit", staffpoint);
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(long id, StaffPoint staffPoint)
        {
            var staffpointRestClient = new StaffPointRestiClient();
            var update = await staffpointRestClient.Update(id, staffPoint);
            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var staffpointRestClient = new StaffPointRestiClient();
            var delete = await staffpointRestClient.Delete(id);
            return RedirectToAction("Index");
        }


        private DateTime AddBusinessDays(DateTime date, int days)
        {
            if (days <= 0)
            {
                throw new ArgumentException("days cannot be negative", "days");
            }
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(2);
                days -= 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
                days -= 1;
            }

            if (days == 1) return date;

            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }
            var newDate = date.AddDays(extraDays);

            return newDate;
        }
    }
}