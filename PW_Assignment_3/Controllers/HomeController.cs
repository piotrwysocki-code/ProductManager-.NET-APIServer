using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PW_Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepo prodRepo;
        private ICategoryRepo catRepo;
        private Site_DBContext dbctx;

        public HomeController(IProductRepo prodRep, ICategoryRepo catRep, Site_DBContext ctx)
        {
            prodRepo = prodRep;
            catRepo = catRep;
            dbctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View(prodRepo.Products);
        }

        [HttpPost]
        public IActionResult addProduct(Product product)
        {
            prodRepo.AddProduct(product);
            dbctx.SaveChanges();

            return RedirectToAction("Products");
        }

        public IActionResult Categories()
        {
            return View(catRepo.Categories);
        }

        [HttpPost]
        public IActionResult addCategory(Category category)
        {
            catRepo.AddCategory(category);
            dbctx.SaveChanges();

            return RedirectToAction("Categories");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
