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
using CSharpExam.Models;

namespace CSharpExam.Controllers
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
                ModelState.AddModelError("Email", "Email in use -- please register with another valid email.");
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
                ViewBag.Activities = _context.Activities
                    .Include(a => a.Participants)
                    .Include(a => a.EventCoordinator)
                    .OrderBy(a => a.Date);
                return View();
            }
            return View("Index");
        }

        // View Activity Form
        [HttpGet("activity-form")]
        public IActionResult ActivityForm()
        {
            return View();
        }

        // Create Activity
        [HttpPost("create-activity")]
        public IActionResult CreateEvent(ActivityEvent newActivityEvent)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    newActivityEvent.EventCoordinator = currentUser;
                    _context.Add(newActivityEvent);
                    _context.SaveChanges();
                    return RedirectToAction("ActivityDetails", new { actId = newActivityEvent.ActivityEventId });
                }
                return View("ActivityForm");
            }
            return View("Index");
        }

        // View Activity Details
        [HttpGet("/activity-details/{actId}")]
        public IActionResult ActivityDetails(int actId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.ThisActivity = _context.Activities
                    .Include(a => a.EventCoordinator)//user
                    .Include(a => a.Participants)//particpant <list>
                        .ThenInclude(p => p.UserSignedUp)
                    .FirstOrDefault(a => a.ActivityEventId == actId);
                ActivityEvent thisActivity = ViewBag.ThisActivity;

                ViewBag.CurrentUser = _context.Users
                    .Include(u => u.RegisteredFor)
                    .FirstOrDefault(u => u.UserId == currentUser.UserId);

                ViewBag.SignedUp = thisActivity.Participants.Any(u => u.UserId == currentUser.UserId);
                return View();
            }
            return View("Index");
        }

        // Add Participant
        [HttpPost("add/participant/{actId}")]
        public IActionResult AddParticipant(int actId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                var newParticipant = new Participant();

                newParticipant.UserId = currentUser.UserId;
                newParticipant.ActivityEventId = actId;
                _context.Add(newParticipant);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        // Remove Participant
        [HttpPost("delete/participant/{actId}")]
        public IActionResult DeleteParticipant(int actId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                Participant participantToRemove = _context.Participants
                    .FirstOrDefault(p => p.ActivityEventId == actId);

                _context.Remove(participantToRemove);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        // Delete Activity
        [HttpPost("delete/activity/{actId}")]
        public IActionResult DeleteActivity(int actId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ActivityEvent activityToRemove = _context.Activities
                    .FirstOrDefault(a => a.ActivityEventId == actId);
                _context.Remove(activityToRemove);
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
