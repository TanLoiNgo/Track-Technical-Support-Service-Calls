using System.Linq;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers
{
    public class ProductController : Controller
    {

        private ApplicationContext context;

        public ProductController(ApplicationContext ctx)
        {
            context = ctx;
        }


        [Route("[controller]s/{cat?}")]
        public IActionResult Index()
        {
            var products = context.Products
                .OrderBy(c => c.ReleasedDate).ToList();


            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Product());
        }
        [HttpGet]
        [Route("[controller]s/{id}")]
        public IActionResult Details(int id)
        {
            var product = context.Products
                .FirstOrDefault(c => c.Id == id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products
                .FirstOrDefault(c => c.Id == id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products
               .FirstOrDefault(c => c.Id == id);
            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.Id == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if(action == "Add")
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    TempData["message"] = product.Name + "  was added Succesfully";
                   
                }
                else
                {
                    TempData["message"] = product.Name + "  was updated Succesfully";
                    context.Products.Update(product);
                    context.SaveChanges();
                }

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Action = action;
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            TempData["message"] = product.Name + "  was deleted Succesfully";
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}
