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
        private IEmployeeRepo empRepo;
        private IDepartmentRepo deptRepo;
        private ISalesRepo salesRepo;
        private ISalesProdRepo spRepo;
        private ICategoryRepo catRepo;
        private Site_DBContext dbctx;

        public HomeController(IProductRepo prodRep, ICategoryRepo catRep, IEmployeeRepo empRep, IDepartmentRepo deptRep, ISalesRepo salesRep, 
            ISalesProdRepo spRep, Site_DBContext ctx)
        {
            prodRepo = prodRep;
            catRepo = catRep;
            empRepo = empRep;
            deptRepo = deptRep;
            salesRepo = salesRep;
            spRepo = spRep;
            dbctx = ctx;
        }
        [HttpGet]
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

        public IActionResult Departments()
        {
            return View(deptRepo.Departments);
        }

        [HttpPost]
        public IActionResult addDepartment(Department dept)
        {
            deptRepo.AddDepartment(dept);
            dbctx.SaveChanges();

            return RedirectToAction("Departments");
        }

        public IActionResult Sales()
        {
            return View(salesRepo.Sales);
        }

        [HttpPost]
        public IActionResult addSale(Sale sale)
        {
            salesRepo.AddSale(sale);
            dbctx.SaveChanges();

            return RedirectToAction("Sales");
        }


        public IActionResult Employees()
        {
            return View(empRepo.Employees);
        }

        [HttpPost]
        public IActionResult addemployee(Employee emp)
        {
            empRepo.AddEmployee(emp);
            dbctx.SaveChanges();

            return RedirectToAction("Employees");
        }

        public IActionResult SalesProducts()
        {
            return View(spRepo.SalesProds);
        }

        [HttpPost]
        public IActionResult addSalesProduct(SalesProd sp)
        {
            spRepo.AddSalesProd(sp);
            dbctx.SaveChanges();

            return RedirectToAction("SalesProducts");
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
