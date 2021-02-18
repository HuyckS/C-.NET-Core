using Microsoft.AspNetCore.Mvc;
using System;

namespace Time_display.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet("")]
        public ViewResult Time()
        {
            ViewBag.CurrentTime = DateTime.Now;
            return View();
        }
    }
}