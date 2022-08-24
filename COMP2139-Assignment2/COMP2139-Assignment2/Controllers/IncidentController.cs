using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_Assignment1.Controllers
{
    public class IncidentController : Controller
    {
        private ApplicationContext context { get; set; }
        public IncidentController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[controller]s/{filter?}")]
        public IActionResult Index(string filter)
        {
            var incidents = context.Incidents
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .OrderBy(t => t.Title).ToList();

            if (filter == "unassigned")
            {
                incidents = incidents.Where(i => i.TechnicianId == null).ToList();

            }
            else if (filter == "open")
            {
                incidents = incidents.Where(i => i.DateClosed == null).ToList();
            }

            return View(incidents);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            var incident = context.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.Id == 0)
                    context.Incidents.Add(incident);
                else
                    context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("Index", "Incident");
            }
            else
            {
                ViewBag.Action = (incident.Id == 0) ? "Add" : "Edit";
                ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
                ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
                return View(incident);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("Index", "Incident");
        }
    }
}