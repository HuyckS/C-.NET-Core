using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CSharpExam2.Models;

namespace CSharpExam2.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        // GetCurrentUser()
        public User GetCurrentUser()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return null;
            }
            return _context.Users.First(u => u.UserId == userId);
        }

        // Login / Register View
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // Handle Register
        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if (_context.Users.Any(u => u.Username == newUser.Username))
            {
                ModelState.AddModelError("Username", "Username taken -- please register with another username between 3 and 15 characters.");
                return View("Index");
            }

            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            }

            return View("Index");
        }

        // Handle Login
        [HttpPost("login-user")]
        public IActionResult LoginUser(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userLogged = _context.Users
                    .FirstOrDefault(u => u.Username == userSubmission.LoginUsername);

                if (userLogged == null)
                {
                    ModelState.AddModelError("LoginUsername", "Invalid Username / Password");
                    return View("Index");
                }

                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userLogged.Password, userSubmission.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginUsername", "Invalid Username / Password");
                    return View("Index");
                }

                HttpContext.Session.SetInt32("UserId", userLogged.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        //View dashboard
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.CurrentUser = currentUser;
                ViewBag.Hobbies = _context.Hobbies
                    .Include(h => h.HobbyEnthusiasts)
                    .Include(h => h.HobbyCreator)
                    .OrderByDescending(h => h.HobbyEnthusiasts.Count);
                return View();
            }
            return View("Index");
        }
        //View hobby form
        [HttpGet("hobby-form")]
        public IActionResult HobbyForm()
        {
            return View();
        }
        //Create hobby
        [HttpPost("create-hobby")]
        public IActionResult CreateHobby(Hobby newHobby)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (_context.Hobbies.Any(h => h.Name == newHobby.Name))
                {
                    ModelState.AddModelError("Name", "Hobby Name must be unique -- please choose another.");
                    return View("HobbyForm");
                }
                if (ModelState.IsValid)
                {
                    newHobby.HobbyCreator = currentUser;
                    _context.Add(newHobby);
                    _context.SaveChanges();
                    return RedirectToAction("HobbyDetails", new { hobbyId = newHobby.HobbyId });
                }
                return View("HobbyForm");
            }
            return View("Index");
        }
        //View Hobby Details
        [HttpGet("hobby-details/{hobbyId}")]
        public IActionResult HobbyDetails(int hobbyId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.ThisHobby = _context.Hobbies
                    .Include(h => h.HobbyCreator)//user
                    .Include(h => h.HobbyEnthusiasts)// list <Enthusiast>
                        .ThenInclude(e => e.UserWhoIsEnthused)
                    .FirstOrDefault(h => h.HobbyId == hobbyId);

                Hobby thisHobby = ViewBag.ThisHobby;

                ViewBag.CurrentUser = _context.Users
                    .Include(u => u.EnthusiastOf)
                    .FirstOrDefault(u => u.UserId == currentUser.UserId);

                ViewBag.SignedUp = thisHobby.HobbyEnthusiasts.Any(e => e.UserId == currentUser.UserId);

                return View();
            }
            return View("Index");
        }
        //process become enthusiast
        [HttpPost("add-enthusiast/{hobbyId}")]
        public IActionResult AddEnthusiast(Enthusiast newEnthusiast, int hobbyId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                newEnthusiast.UserId = currentUser.UserId;
                newEnthusiast.HobbyId = hobbyId;
                _context.Add(newEnthusiast);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        // Logout
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
