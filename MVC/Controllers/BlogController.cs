using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BlogController : Controller
    {
        [Route("Blog")]
        [Route("Blog/Index")]
        [Route("Blog/Index/{id?}")]
        public IActionResult Index()
        {
            return Ok("Action of Blog is Called");
        }

        public IActionResult Article()
        {
            return Ok("Action of Blog's Article is Called");
        }
        
    }
}
