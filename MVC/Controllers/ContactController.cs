using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    //Step 3
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        //Step 4
        [Route("Main")]
        public IActionResult Index()
        {
            return Ok("Action Main is Called");
        }
        //Step 5
        public IActionResult ContactDetail(int id)
        {
            return Ok("Action Detail");
        }
    }
}
