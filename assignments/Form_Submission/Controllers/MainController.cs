using Microsoft.AspNetCore.Mvc;
using Form_Submission.Models;
using System;

namespace Form_Submission.Controllers
{
    public class MainController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/create-user")]
        public IActionResult CreateUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(newUser.FirstName);
                return View(newUser);
            }
            else
            {
                return View("Index");
            }
        }
    }
}