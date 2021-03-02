using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserDashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace UserDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View();
        }

        public User GetCurrentUser()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return null;
            }
            return _context.Users.First(u => u.UserId == userId);
        }
        //Login View
        [HttpGet("signin")]
        public IActionResult SignIn()
        {
            return View();
        }
        //Process Login
        //Register View
        [HttpPost("register")]
        public IActionResult Register()
        {
            return View();
        }

        //Process Register
        [HttpPost("sign-up")]
        public IActionResult SignUp(User newUser)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email in use -- please register with another valid email or sign in.");
                return View("register");
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

            return View("register");
        }

        //Log out
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Home");
        }

        //User Dashboard View
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.CurrentUser = currentUser;
                ViewBag.Projects = _context.Projects;
                ViewBag.Taskers = _context.Taskers;
                return View();
            }
            return View("Home");
        }

        //User Edit View
        [HttpGet("edit-account")]
        public IActionResult UserEdit()
        {
            return View();
        }

        //User Project Details Page
        [HttpGet("project-details/{projectId}")]
        public IActionResult ProjectDetails(int projectId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.ThisProject = _context.Projects
                    .FirstOrDefault(p => p.ProjectId == projectId);

                ViewBag.CurrentUser = _context.Users
                    .FirstOrDefault(u => u.UserId == currentUser.UserId);

                return View();
            }
            return View("Home");
        }

        //Process Create Tasker Form
        [HttpPost("create-tasker")]
        public IActionResult CreateEvent(Tasker newTasker)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    //make sure projectId is past with the post when project is selected
                    newTasker.UserId = currentUser.UserId;
                    _context.Add(newTasker);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                return View("Dashboard");
            }
            return View("Home");
        }
        //User Delete Tasker
        //User Create Project Form
        //Process Create Project
        [HttpPost("create-project")]
        public IActionResult CreateProject(Project newProject)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    newProject.ProjectCreator = currentUser;
                    _context.Add(newProject);
                    _context.SaveChanges();
                    return RedirectToAction("ProjectDetails", new { projectId = newProject.ProjectId });
                }
                return View("Dashboard");
            }
            return View("Home");
        }
        //User Delete Project
        //Process Create Message Form
        [HttpPost("create-message")]
        public IActionResult CreateMessage(Message newMessage)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    newMessage.Sender = currentUser;
                    _context.Add(newMessage);
                    _context.SaveChanges();
                    return RedirectToAction("ProjectDetails", new { projectId = newMessage.ProjectWithMessage.ProjectId });
                }
                return View("ProjectDetails");
            }
            return View("Home");
        }
        //Admin Dashboard View
        //

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

    }
}
