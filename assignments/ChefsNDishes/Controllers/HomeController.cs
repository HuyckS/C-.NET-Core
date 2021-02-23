using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Chefs = _context.Chefs
                .Include(c => c.CreatedDishes);

            return View();
        }

        [HttpGet("chef-form")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("create-chef")]
        public IActionResult CreateChef(Chef newChef)
        {

            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("dish-form")]
        public IActionResult AddDish()
        {
            ViewBag.Chefs = _context.Chefs;
            return View();
        }

        [HttpPost("create-dish")]
        public IActionResult CreateDish(Dish newDish)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("dishes")]
        public IActionResult DishesIndex()
        {
            ViewBag.Dishes = _context.Dishes;
                .Include(d => d.Creator);
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
