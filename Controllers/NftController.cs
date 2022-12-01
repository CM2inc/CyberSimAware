using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    public class NftController : Controller
    {
        private ShopContext context;

        public NftController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Nft");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

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

            // use ViewBag to pass data to view
            /*
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

        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            Nft nft = context.Nfts.Find(id);

            string imageFilename = nft.Code + "_m.png";

            // use ViewBag to pass data to view
            ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            // bind nft to view
            return View(nft);
        }
    }
}