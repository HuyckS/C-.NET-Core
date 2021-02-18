using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Random_Passcode.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            int? curr = HttpContext.Session.GetInt32("count");
            if (curr == null)
            {
                HttpContext.Session.SetInt32("count", 0);
            }
            else
            {
                int currCount = (int)curr + 1;
                HttpContext.Session.SetInt32("count", currCount);
            }
            Passcode newPass = new Passcode();
            ViewBag.Pass = newPass.randomPasscode;
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            return View();
        }

        // [HttpGet("/create-passcode")]
        // public IActionResult CreatePasscode()
        // {

        //     int? curr = HttpContext.Session.GetInt32("count");
        //     if (curr == null)
        //     {
        //         HttpContext.Session.SetInt32("count", 0);
        //     }
        //     else
        //     {
        //         HttpContext.Session.SetInt32("count", (int)curr++);
        //     }
        //     Passcode newPass = new Passcode();
        //     ViewBag.Pass = newPass.randomPasscode;
        //     ViewBag.Count = HttpContext.Session.GetInt32("count");
        //     return Redirect("Index");
        // }

    }
}
