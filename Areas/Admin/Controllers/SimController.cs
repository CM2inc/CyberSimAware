using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberSimAware.Models;

namespace CyberSimAware.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SimController : Controller
    {
        private ShopContext context;
        private List<Category> categories;

        public SimController(ShopContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
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

            /*
            // use ViewBag to pass category data to view
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

        [HttpGet]
        public IActionResult Add()
        {
            // create new Sim object
            Sim sim = new Sim();                // create Sim object
            sim.Category = context.Categories.Find(1);  // add Category object - prevents validation problem

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            // bind sim to AddUpdate view
            return View("AddUpdate", sim);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Sim object for specified primary key
            Sim sim = context.Sims
                .Include(p => p.Category)
                .FirstOrDefault(p => p.SimID == id);

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            // bind sim to AddUpdate view
            return View("AddUpdate", sim);
        }

        [HttpPost]
        public IActionResult Update(Sim sim)
        {
            if (ModelState.IsValid)
            {
                if (sim.SimID == 0)           // new sim
                {
                    context.Sims.Add(sim);
                    TempData["UserMessage"] = "you just added the sim " + sim.Name;
                    //TempData["you just added the project " + sim] = "UserMessage";
                }
                else                                  // existing sim
                {
                    context.Sims.Update(sim);
                    TempData["UserMessage"] = "you just updated the sim " + sim.Name;
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", sim);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Sim sim = context.Sims
                .FirstOrDefault(p => p.SimID == id);
            return View(sim);
        }

        [HttpPost]
        public IActionResult Delete(Sim sim)
        {
            context.Sims.Remove(sim);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}