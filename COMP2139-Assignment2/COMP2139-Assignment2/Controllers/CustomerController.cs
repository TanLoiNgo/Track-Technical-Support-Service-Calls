using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationContext context { get; set; }
        public CustomerController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[controller]s")]

        public IActionResult Index()
        {
            
            var cutomers = context.Customers
                .Include(c => c.Country)
                .OrderBy(c => c.FirstName).ToList();
            return View(cutomers);
        }
        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            if (TempData["okEmail"] == null)
            {
                string msg = Check.EmailExists(context, customer.Email);
                if (!String.IsNullOrEmpty(msg))
                {
                    ModelState.AddModelError(nameof(Customer.Email), msg);
                }
            }
            var cutomers = context.Customers
                .Include(c => c.Country)
                .OrderBy(c => c.FirstName).ToList();
            return View(cutomers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            var customer = context.Customers.Find(id);
            return View(customer);
        }
   
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                    context.Customers.Add(customer);
                else
                    context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Action = (customer.Id == 0) ? "Add" : "Edit";
                ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}