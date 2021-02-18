using Microsoft.AspNetCore.Mvc;

namespace Razor_fun.Controllers
{
    public class FoodController : Controller
    {
        [HttpGet("")]
        public ViewResult Food()
        {
            return View();
        }

    }
}