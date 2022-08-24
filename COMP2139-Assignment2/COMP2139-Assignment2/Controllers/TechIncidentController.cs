using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2139_Assignment1.ExtensionMethods;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP2139_Assignment1.Controllers
{
    public class TechIncidentController : Controller
    {
        private ApplicationContext context { get; set; }

        public TechIncidentController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var technicians = context.Technicians
                .OrderBy(t => t.Name).ToList();
            return View(technicians);
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var session = new AppSession(HttpContext.Session);
            int techId = session.GetTechnicianId();

            if (session.GetTechnicianId() == 0)
            {
                techId = id;

            }
            else
            {
                techId = session.GetTechnicianId();
            }

            var technician = context.Technicians.Where(t => t.Id == techId)
                .FirstOrDefault();

            ViewBag.TechName = technician.Name;

            ViewBag.Incidents = context.Incidents
                .Include(t => t.Customer)
                .Include(t => t.Product)
                .Where(t => t.TechnicianId == techId)
                .ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var incident = context.Incidents.Include(i => i.Customer).Include(i => i.Product).Where(i => i.Id == id).FirstOrDefault();
            ViewBag.Customer = incident.Customer;
            ViewBag.Technician = incident.Technician;
            ViewBag.Product = incident.Product;
            return View(incident);
        }

       

        [HttpPost]

        public IActionResult Select(Incident incident)
        {


            var session = new AppSession(HttpContext.Session);
            session.SetTechnician(incident.Id);

            return RedirectToAction("List", new { ID = incident.Id });
        }
    }
}
