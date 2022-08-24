using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1.ExtensionMethods;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP2139_Assignment1.Controllers
{
    public class RegistrationController : Controller
    {
        private ApplicationContext context { get; set; }

        public RegistrationController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[controller]s/{id?}")]
        public IActionResult List(int id)
        {
            var session = new AppSession(HttpContext.Session);
            int customerId = session.GetCustomerId();
            if (session.GetCustomerId() == 0)
            {
                customerId = id;

            }
            else
            {
                customerId = session.GetCustomerId();
            }

            var products = context.Products
                .OrderBy(c => c.ReleasedDate).ToList();

            var customer = context.Customers.Where(c => c.Id == customerId)
                .FirstOrDefault();

            ViewBag.CustomerName = customer.FullName;
            ViewBag.CustomerId = customerId;
            ViewBag.Products = products;

            ViewBag.Registrations = context.Registrations
                .Include(r => r.Product)
                .Where(r => r.CustomerId == customerId)
                .ToList();

            return View();
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var customers = context.Customers
                .Include(c => c.Country)
                .OrderBy(c => c.FirstName).ToList();
            return View(customers);
        }

        [HttpPost]
        public IActionResult Select(int id)
        {
            var session = new AppSession(HttpContext.Session);
            session.SetCustomer(id);
            return RedirectToAction("List", new { ID = id });
        }


        [HttpPost]
        public IActionResult Delete(Registration reg)
        {

            context.Registrations.Remove(reg);
            context.SaveChanges();
            return RedirectToAction("List", "Registration");

        }

        [HttpPost]
        public IActionResult Register(Registration reg)
        {
            if (ModelState.IsValid)
            {
                context.Registrations.Add(reg);
                context.SaveChanges();
                return RedirectToAction("List", "Registration");
            }

            return View(reg);
        }
    }
}
