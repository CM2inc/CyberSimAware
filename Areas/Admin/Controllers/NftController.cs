using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NftTracker.Models;

namespace NftTracker.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NftController : Controller
    {
        private ShopContext context;
        private List<Category> categories;

        public NftController(ShopContext ctx)
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
            List<Nft> nfts;
            if (id == "All")
            {
                nfts = context.Nfts
                    .OrderBy(p => p.NftID).ToList();
            }
            else
            {
                nfts = context.Nfts
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.NftID).ToList();
            }

            /*
            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;
            */

            //~~populated the view model
            var model = new NftListViewModel
            {
                Categories = categories,
                Nfts = nfts,
                SelectedCategory = id
            };

            // bind nfts to view
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // create new Nft object
            Nft nft = new Nft();                // create Nft object
            nft.Category = context.Categories.Find(1);  // add Category object - prevents validation problem

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            // bind nft to AddUpdate view
            return View("AddUpdate", nft);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Nft object for specified primary key
            Nft nft = context.Nfts
                .Include(p => p.Category)
                .FirstOrDefault(p => p.NftID == id);

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            // bind nft to AddUpdate view
            return View("AddUpdate", nft);
        }

        [HttpPost]
        public IActionResult Update(Nft nft)
        {
            if (ModelState.IsValid)
            {
                if (nft.NftID == 0)           // new nft
                {
                    context.Nfts.Add(nft);
                    TempData["UserMessage"] = "you just added the nft " + nft.Name;
                    //TempData["you just added the project " + nft] = "UserMessage";
                }
                else                                  // existing nft
                {
                    context.Nfts.Update(nft);
                    TempData["UserMessage"] = "you just updated the nft " + nft.Name;
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", nft);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Nft nft = context.Nfts
                .FirstOrDefault(p => p.NftID == id);
            return View(nft);
        }

        [HttpPost]
        public IActionResult Delete(Nft nft)
        {
            context.Nfts.Remove(nft);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}