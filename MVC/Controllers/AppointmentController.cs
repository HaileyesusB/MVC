using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            string todyasDate = DateTime.Now.ToShortDateString();
            return Ok(todyasDate);
        }

        public IActionResult details(int id) 
        {
            return Ok("You have Intered" + id);        
        }
    }
}
