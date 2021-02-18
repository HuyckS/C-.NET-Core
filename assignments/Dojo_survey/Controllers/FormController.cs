using System;
using Microsoft.AspNetCore.Mvc;
using Dojo_survey.Models;

namespace Dojo_survey.Controllers
{
    public class FormController : Controller
    {

        [HttpGet("")]
        public ViewResult Form()
        {
            return View();
        }

        [HttpPost("/result")]
        public IActionResult Result(Survey newResult)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(newResult.Name);
                return View(newResult);
            }
            else
            {
                return View("Form");
            }
        }
    }

}