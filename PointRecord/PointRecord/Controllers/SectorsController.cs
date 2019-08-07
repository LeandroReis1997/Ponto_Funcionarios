using Microsoft.AspNetCore.Mvc;
using PointRecord.Models.Sector;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PointRecord.Controllers
{
    [Route("sectors")]
    public class SectorsController : Controller
    {
        #region Read
        public async Task<IActionResult> Index()
        {
            var sectorsRestClient = new SectorsRestClient();
            var sectors = await sectorsRestClient.GetAll
            ().Result.Content.ReadAsAsync<List<Sectors>>();
            return View(sectors);
        }
        #endregion

        #region Create
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Sectors());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Sectors sectors)
        {
            var sectorsRestClient = new SectorsRestClient();
            var create = await sectorsRestClient.Create(sectors);
            return RedirectToAction("Index", create);
        }
        #endregion

        #region Update
        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var sectorsRestClient = new SectorsRestClient();
            var sectors = sectorsRestClient.Find
                (id).Result.Content.ReadAsAsync<Sectors>().Result;
            return View("Edit", sectors);
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, Sectors sectors)
        {
            var sectorsRestClient = new SectorsRestClient();
            var update = await sectorsRestClient.Update(id, sectors);
            return RedirectToAction("Index", update);
        }
        #endregion

        #region Delete
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sectorsRestClient = new SectorsRestClient();
            var remover = await sectorsRestClient.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}