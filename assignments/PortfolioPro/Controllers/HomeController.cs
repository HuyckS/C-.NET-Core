using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioPro.Models;

namespace PortfolioPro.Controllers
{
    public class HomeController : Controller
    {
        //for each route this controller is to handle:
        [HttpGet("")]     //associated route string (exclude the leading /) 
        public ViewResult Home()
        {
            return View("Home");
        }

        [HttpGet("/resume")]
        public ViewResult Resume()
        {
            return View("Resume");
        }

        [HttpGet("/projects")]
        public ViewResult Projects()
        {
            return View("Projects");
        }

        [HttpGet("/skills")]
        public ViewResult Skills()
        {
            return View("Skills");
        }

        [HttpGet("/contact")]
        public ViewResult Contact()
        {
            return View("Contact");
        }
    }
}
