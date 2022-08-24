using Microsoft.AspNetCore.Mvc;
using COMP2139_Assignment1.Models;
namespace COMP2139_Assignment1.Controllers
{
    public class ValidationController : Controller
    {
        private ApplicationContext context;
        public ValidationController(ApplicationContext ctx) => context = ctx;

        public JsonResult CheckEmail(string email)
        {
            string msg = Check.EmailExists(context, email);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }

    }
}
