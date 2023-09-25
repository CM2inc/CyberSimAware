using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CyberSimAware.Models;

namespace CyberSimAware.Controllers
{
    public class SimController : Controller
    {
        private ShopContext context;

        public SimController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Sim");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            List<Sim> sims;
            if (id == "All")
            {
                sims = context.Sims
                    .OrderBy(p => p.SimID).ToList();
            }
            else
            {
                sims = context.Sims
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.SimID).ToList();
            }

            // use ViewBag to pass data to view
            /*
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;
            */

            //~~populated the view model
            var model = new SimListViewModel
            {
                Categories = categories,
                Sims = sims,
                SelectedCategory = id
            };

            // bind sims to view
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            Sim sim = context.Sims.Find(id);

            string imageFilename = sim.Code + "s.png";

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            // bind sim to view
            return View(sim);
        }
    }
}