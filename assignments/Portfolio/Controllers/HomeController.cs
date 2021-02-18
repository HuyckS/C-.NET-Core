using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        //for each route this controller is to handle:
        [HttpGet("")]     //associated route string (exclude the leading /) 
        public ViewResult Home()
        {
            return View("Home");
        }

        [HttpGet("/projects")]
        public ViewResult Projects()
        {
            return View("Projects");
        }

        [HttpGet("/contact")]
        public ViewResult Contact()
        {
            return View("Contact");
        }
    }
}