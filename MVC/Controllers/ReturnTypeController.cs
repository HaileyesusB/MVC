using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ReturnTypeController : Controller
    {
        private readonly IWebHostEnvironment _IhostEnvironment;

        public ReturnTypeController(IWebHostEnvironment IhostEnvironment)
        {
            _IhostEnvironment = IhostEnvironment;
        }
        #region ::Status Code Results::
        /// <summary>
        /// This is a Status Code Results when they are executed
        /// </summary>
        /// <returns></returns>

        public IActionResult OkResult()
        {
            return Ok();
        }
        /// <summary>
        /// returns a Created 201 response with a Locator heaser
        /// This indicate the request has been fullfilled and has resulted 
        /// In one or more new resources being created
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult CreatedResults()
        {
            return Created("http://example.org/myitem", new { name = "newItem" });
        }

        /// <summary>
        /// returns a Created 204 status code
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult NoContentResults()
        {
            return NoContent();
        }

        /// <summary>
        /// An ObjectResult, When executed. will produce a Bad Request (400) response.
        /// It indicate a bad request by the user
        /// It does not take any argument.
        /// </summary>
        /// <returns></returns>
        /// 

        public IActionResult BadRequestResult() 
        {
            return BadRequest();        
        }

        /// <summary>
        /// UnAutorizedResult returns 401 status code, its diffrence with
        /// challengeResult is that it just returns an status code and doesn't
        /// do anything else
        /// It contrast with its counterpart that has many options for
        /// redirecting the user and options related to asp.net core identity.
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult UnAutorizedResult()
        {
            return Unauthorized();
        }

        /// <summary>
        /// Represents a StatusCodeResult that when executed, will produce
        /// a Not Found (404) response
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult NotFoundResult()
        {
            return NotFound();
        }

        /// <summary>
        /// This action result returns 415 status code, which means server can not 
        /// continue to process the request with the given payload
        /// It is doing this by inspecting th Content-Type or Content-Encoding
        /// of the current request or inspecting the incoming data directly
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult UnsupportedMediaTypeResult()
        {
            return new UnsupportedMediaTypeResult();
        }
        #endregion

        #region ::Status Code with object Result::

        /// <summary>
        /// An ObjectResult, Whe Executed, Perform content negotiation,
        /// formats the entity body, and will produce a status 200Ok response
        /// If negotiation and formatting succeed
        /// </summary>
        /// <returns></returns>
        public IActionResult OkObjectResult()
        {
            var result = new OkObjectResult(new { message = "200 Ok", currentDate = DateTime.Now });
            return result;
        }


        /// <summary>
        /// CreatedAtActionResult that returns a created (201) response with a Location header.
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatedObjectResult()
        {
            var result = new CreatedAtActionResult("Createdobjectresult" , "statuscodeobject", "", new { message = "201 created", currentDate = DateTime.Now});
            return result;

        }

        /// <summary>
        /// This is similar to BasRequestResult, with the diffrence that
        /// it can pass an object or a ModelStateDictionary containing the 
        /// details regarding the error.
        /// </summary>
        /// <returns></returns>
        public IActionResult BadRequestObjectResult()
        {
            var result = new BadRequestObjectResult( new { message = "400 Bad Request", currentDate = DateTime.Now });
            return result;
        }

        /// <summary>
        /// This is similar to NotFoundResult, with the diffrence being that
        /// you can pass an object with the 404 response.
        /// </summary>
        /// <returns></returns>
        public IActionResult NotFoundObjectResult()
        {
            var result = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
            return result;
        }
        #endregion

        #region ::Redirect Result::

        /// <summary>
        /// Redirect to specified string URL with permanent 301 property set to false
        /// </summary>
        /// <returns></returns>
        public IActionResult RedirectResult()
        {
            return Redirect("https://www.google.com");
        }

        /// <summary>
        /// Redirect to specified  URL is it's local URL (also relative),
        /// if not it willthrow an exception. permanent 301 property set to false.
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult LocalRedirectResult()
        {
            return LocalRedirect("/redirect/target");
        }

        /// <summary>
        /// RedirectToActionResult can redirect us to an action.
        /// It takes in the action name, controller name, and route value.
        /// if not it willthrow an exception. permanent 301 property set to false.
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult RedirectToActionResult()
        {
            return RedirectToAction("target", "Appointment");
        }
        #endregion

        #region ::File Result::

        /// <summary>
        /// Returns the file content as PDF content.
        /// </summary>
        /// <returns></returns>
        public IActionResult FileResult()
        {
            return File("~/downloads/pdf-sample.pdf" , "application/pdf");
        }
        /// <summary>
        /// Returns the file as an array of bytes as you see in FileContentActionResult . 
        /// </summary>
        /// <returns></returns>
        public IActionResult FileContentActionResult()
        {
            //Get the byte array for the document
            var pdfBytes = System.IO.File.ReadAllBytes("wwwroot/downloads/pdf-samlple.pdf");

            //FileContentResult needs a byte array and return a file.
            //With the specified content type.
            return new FileContentResult(pdfBytes, "application/pdf");
        }

        /// <summary>
        /// Use VirtualFileResult if you want to read a file form
        /// a virtual address and return it
        /// </summary>
        /// <returns></returns>
        public IActionResult VirtualFileResult()
        {
           return new VirtualFileResult("/downloads/pdf-samlple.pdf", "application/pdf");
        }

        /// <summary>
        /// Use PhysicalFileResult to read a file from a physical address and return it.
        /// </summary>
        /// <returns></returns>
        public IActionResult PhysicalFileResult()
        {
            return new PhysicalFileResult(_IhostEnvironment.ContentRootPath + "/wwwroot/downloads/pdf-samlple.pdf", "application/pdf");
        }

        #endregion

        #region ::Content Result::

        /// <summary>
        /// It Renders a specified view to the response stream.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  Renders a specified partial view to the response stream.
        /// </summary>
        /// <returns></returns>
        
       public IActionResult PartialViewResult()
        {
            return PartialView();
        }

        /// <summary>
        ///  Renders JSONResult (JavaScript Object Notation Result)
        /// </summary>
        /// <returns></returns>

        public IActionResult JSONResult()
        {
            return Json(new { message = "This is JSON result.", date = DateTime.Now });
        }

        /// <summary>
        /// It display the response stream without requiring a view.
        /// </summary>
        /// <returns></returns>
        public IActionResult ContentResult()
        {
            return Content("Here's the ContentResult message");
        }
        #endregion

    }


}

