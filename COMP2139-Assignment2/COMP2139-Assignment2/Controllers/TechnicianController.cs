using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP2139_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP2139_Assignment1.Controllers
{
    public class TechnicianController : Controller
    {
        private ApplicationContext context { get; set; }

        public TechnicianController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[controller]s/{cat?}")]
        public IActionResult Index()
        {
            var technicians = context.Technicians
                .OrderBy(t => t.Name).ToList();
            return View(technicians);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(t => t.Id == id);
            return View(technician);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians
                .FirstOrDefault(t => t.Id == id);
            return View(technician);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(t => t.Id == id);
            return View(technician);
        }


        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.Id == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Technicians.Add(technician);
                    context.SaveChanges();
                }
                else
                {
                    context.Technicians.Update(technician);
                    context.SaveChanges();
                }

                return RedirectToAction("Index", "Technician");
            }
            else
            {
                ViewBag.Action = action;
                return View(technician);
            }
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("Index", "Technician");
        }
    }
}
