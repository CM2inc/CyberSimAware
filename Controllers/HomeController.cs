using Microsoft.AspNetCore.Mvc;

namespace CyberSimAware.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }
        [Route("[action]")]
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}
