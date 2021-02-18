using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Http;


namespace CRUDelicious.Controllers
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
            var Dishes = _context.Dishes
                .OrderByDescending(d => d.UpdatedAt)
                .ToArray();


            return View(Dishes);
        }

        [HttpGet("dish-form")]
        public IActionResult DishForm()
        {
            return View();
        }

        [HttpPost("create-dish")]
        public IActionResult CreateDish(Dish newDish)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("dish/{id}/view")]
        public IActionResult ViewDish(int id)
        {
            ViewBag.thisDish = _context.Dishes
                .FirstOrDefault(d => d.DishId == id);

            return View();
        }

        [HttpGet("dish/{id}/edit")]
        public IActionResult EditDish(int id)
        {
            Dish dishToEdit = _context.Dishes
                .FirstOrDefault(d => d.DishId == id);

            return View(dishToEdit);
        }

        [HttpPost("update-dish")]
        public IActionResult UpdateDish(Dish updatedDish)
        {
            var thisDish = _context.Dishes
                .FirstOrDefault(dish => dish.DishId == updatedDish.DishId);

            thisDish.DishName = updatedDish.DishName;
            thisDish.ChefName = updatedDish.ChefName;
            thisDish.Calories = updatedDish.Calories;
            thisDish.Description = updatedDish.Description;
            thisDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("ViewDish", new { id = updatedDish.DishId });
        }

        [HttpGet("dish/{id}/delete")]
        public IActionResult DeleteDish(int id)
        {
            var dishToDelete = _context.Dishes
                .FirstOrDefault(dish => dish.DishId == id);

            _context.Dishes.Remove(dishToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
