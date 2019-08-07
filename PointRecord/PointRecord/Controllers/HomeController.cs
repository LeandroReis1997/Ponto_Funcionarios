using Microsoft.AspNetCore.Mvc;

namespace PointRecord.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        #region Read
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}