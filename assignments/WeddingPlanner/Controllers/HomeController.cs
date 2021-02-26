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
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
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
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email invalid");
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
                    .FirstOrDefault(u => u.Email == userSubmission.LoginEmail);

                if (userLogged == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email / Password");
                    return View("Index");
                }

                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userLogged.Password, userSubmission.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email / Password");
                    return View("Index");
                }

                HttpContext.Session.SetInt32("UserId", userLogged.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        // Dashboard View
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.CurrentUser = currentUser;
                ViewBag.Weddings = _context.Weddings
                    .Include(w => w.WeddingRSVPs)
                    .Include(w => w.WeddingPlanner);
                return View();
            }
            return View("Index");
        }
        // Create Wedding View
        [HttpGet("create-wedding")]
        public IActionResult CreateWedding()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
            {
                return View("Index");
            }
            return View();
        }
        // Handle Add Wedding
        [HttpPost("new-wedding")]
        public IActionResult NewWedding(Wedding newWedding)
        {
            if (ModelState.IsValid)
            {
                User currentUser = GetCurrentUser();

                if (currentUser != null)
                {
                    newWedding.WeddingPlanner = currentUser;
                    var address = newWedding.WeddingAddress;
                    newWedding.WeddingAddress = "https://www.google.com/maps/embed/v1/place?key=AIzaSyCOtx7HHjvK-8gn-0OGNnnrs1HT9RGWGXI&q=" + address;
                    // "https://www.google.com/maps/embed/v1/place?key=AIzaSyCOtx7HHjvK-8gn-0OGNnnrs1HT9RGWGXI&q=" + address;
                    _context.Add(newWedding);
                    _context.SaveChanges();

                    return RedirectToAction("WeddingDetails", new { wedId = newWedding.WeddingId });
                }
                else
                {
                    return View("Index");
                }
            }
            return View("Dashboard");
        }
        // Handle Delete Wedding

        [HttpPost("delete/wedding/{wedId}")]
        public IActionResult DeleteWedding(int wedId)
        {
            Wedding weddingToRemove = _context.Weddings
                .FirstOrDefault(w => w.WeddingId == wedId);

            _context.Remove(weddingToRemove);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");

        }

        // Wedding Details View
        [HttpGet("wedding-details/{wedId}")]
        public IActionResult WeddingDetails(int wedId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser == null)
            {
                return View("Index");
            }
            ViewBag.ThisWedding = _context.Weddings
                .Include(w => w.WeddingRSVPs)
                    .ThenInclude(r => r.UserWhoRSVPd)
                .FirstOrDefault(w => w.WeddingId == wedId);
            ViewBag.CurrentUser = currentUser;
            return View();
        }

        //Handle New RSVP
        [HttpPost("add/rsvp/{wedID}")]
        public IActionResult AddRSVP(int wedID)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                var newRSVP = new RSVP();

                newRSVP.UserId = currentUser.UserId;
                newRSVP.WeddingId = wedID;

                _context.Add(newRSVP);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            return View("Index");

        }

        //Handle Delete RSVP
        [HttpPost("delete/rsvp/{WedId}")]
        public IActionResult DeleteRSVP(int WedId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                RSVP rsvpToRemove = _context.RSVPs
                .FirstOrDefault(r => r.WeddingId == WedId && r.UserId == currentUser.UserId);

                _context.Remove(rsvpToRemove);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        // Handle Logout
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
