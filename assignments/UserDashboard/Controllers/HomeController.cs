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
            ViewBag.CurrentUser = GetCurrentUser();
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
            ViewBag.CurrentUser = GetCurrentUser();
            return View();
        }
        //Process Login
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
                    return View("SignIn");
                }

                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userLogged.Password, userSubmission.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email / Password");
                    return View("SignIn");
                }

                HttpContext.Session.SetInt32("UserId", userLogged.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("SignIn");
        }
        //Register View
        [HttpGet("register")]
        public IActionResult Register()
        {
            ViewBag.CurrentUser = GetCurrentUser();
            return View();
        }

        //Process Register
        [HttpPost("sign-up")]
        public IActionResult SignUp(User newUser)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email in use -- please register with another valid email or sign in.");
                return View("Register");
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

            return View("Register");
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
                User projectsLeading = _context.Users
                    .Include(u => u.CreatedProjects)
                    .FirstOrDefault(u => u.UserId == currentUser.UserId);
                User userInfo = _context.Users
                    .Include(u => u.AssignedProjects)
                        .ThenInclude(a => a.ProjectForUser)
                            .ThenInclude(p => p.ProjectTaskers)
                    .FirstOrDefault(u => u.UserId == currentUser.UserId);
                var messages = _context.Messages;
                List<Message> userMessages = new List<Message>();
                foreach (Message m in messages)
                {
                    if (userInfo.AssignedProjects.Any(a => a.ProjectId == m.ProjectId))
                    {
                        userMessages.Add(m);
                    }
                }
                ViewBag.Projects = _context.Projects;
                ViewBag.ProjectsLeading = projectsLeading;
                ViewBag.CurrentUser = userInfo;
                ViewBag.UserMessages = userMessages;
                return View();
            }
            return View("SignIn");
        }

        //User Edit View
        [HttpGet("edit-account")]
        public IActionResult UserEdit()
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                return View();
            }
            return View("SignIn");
        }

        //User update account
        [HttpPost("update-account")]
        public IActionResult UpdateAccount(User updatedUser) // this is coming from the form
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                currentUser.FirstName = updatedUser.FirstName;
                currentUser.LastName = updatedUser.LastName;
                currentUser.Email = updatedUser.Email;
                currentUser.Password = updatedUser.Password;
                currentUser.UpdatedAt = DateTime.Now;
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            return View("SignIn");
        }

        //User Create Project Form
        [HttpGet("project-form")]
        public IActionResult ProjectForm()
        {
            return View();
        }
        //Process Create Project
        [HttpPost("create-project")]
        public IActionResult CreateProject(Project newProject)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (_context.Projects.Any(p => p.Title == newProject.Title))
                {
                    ModelState.AddModelError("Title", "Project Title already in use -- please choose another.");
                    return View("ProjectForm");
                }

                if (ModelState.IsValid)
                {
                    newProject.ProjectLead = currentUser;
                    _context.Add(newProject);
                    _context.SaveChanges();
                    Assignment newAssignment = new Assignment();
                    newAssignment.UserForProject = currentUser;
                    newAssignment.ProjectForUser = newProject;
                    _context.SaveChanges();
                    // newProject.AssignedUsers.Add(newAssignment);
                    // _context.SaveChanges();
                    return RedirectToAction("ProjectDetails", new { projectId = newProject.ProjectId });
                }
                return View("ProjectForm");
            }
            return View("SignIn");
        }

        //User Project Details Page
        [HttpGet("project-details/{projectId}")]
        public IActionResult ProjectDetails(int projectId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                ViewBag.ThisProject = _context.Projects
                    .Include(p => p.ProjectTaskers)
                    .Include(p => p.ProjectMessages)
                        .ThenInclude(m => m.Sender)
                    .Include(p => p.ProjectMessages)
                        .ThenInclude(m => m.CommentsOnMessage)
                            .ThenInclude(c => c.CreatorOfComment)
                    .FirstOrDefault(p => p.ProjectId == projectId);
                ViewBag.CurrentUser = _context.Users
                    .FirstOrDefault(u => u.UserId == currentUser.UserId);
                ViewBag.Users = _context.Users;

                return View();
            }
            return View("SignIn");
        }

        //Process Create Tasker Form
        [HttpPost("create-tasker/{projectId}")]
        public IActionResult CreateTasker(Tasker newTasker, int projectId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(newTasker);
                    _context.SaveChanges();
                    newTasker.ProjectId = projectId;
                    _context.SaveChanges();
                    return RedirectToAction("ProjectDetails", new { projectId = newTasker.ProjectId });
                }
                return View("ProjectDetails", new { projectId = newTasker.ProjectId });
            }
            return View("SignIn");
        }
        //Update Tasker Completion
        [HttpPost("form-check-input/{taskerId}")]
        public IActionResult UpdateCompletion(int taskerId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                Tasker taskerToUpdate = _context.Taskers
                    .FirstOrDefault(t => t.TaskerId == taskerId);

                if (taskerToUpdate.TaskerComplete == false)
                {
                    taskerToUpdate.TaskerComplete = true;
                }
                else
                {
                    taskerToUpdate.TaskerComplete = false;
                }
                _context.SaveChanges();
                Console.WriteLine(taskerToUpdate.ProjectId);
                return View("ProjectDetails", new { projectId = taskerToUpdate.ProjectId });
            }
            return View("SignIn");
        }
        //User Delete Tasker
        [HttpPost("delete-tasker/{taskerId}")]
        public IActionResult DeleteTasker(int taskerId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                Tasker taskerToRemove = _context.Taskers
                    .FirstOrDefault(t => t.TaskerId == taskerId);

                _context.Remove(taskerToRemove);
                _context.SaveChanges();
                return RedirectToAction("ProjectDetails", new { projectId = taskerToRemove.ProjectId });
            }
            return View("SignIn");
        }
        //Process Create Message Form
        [HttpPost("create-message")]
        public IActionResult CreateMessage(Message newMessage)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    // newMessage.ProjectId = projectId;
                    _context.Add(newMessage);
                    _context.SaveChanges();
                    return RedirectToAction("ProjectDetails", new { projectId = newMessage.ProjectId });
                }
                return View("ProjectDetails");
            }
            return View("SignIn");
        }
        //Process Create Comment Form
        [HttpPost("create-comment/{messageId}")]
        public IActionResult CreateComment(Comment newComment, int messageId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                if (ModelState.IsValid)
                {
                    newComment.MessageId = messageId;
                    _context.Add(newComment);
                    _context.SaveChanges();
                    Message messageOfProject = _context.Messages
                        .FirstOrDefault(m => m.MessageId == messageId);
                    return RedirectToAction("ProjectDetails", new { projectId = messageOfProject.ProjectId });
                }
                return View("ProjectDetails");
            }
            return View("SignIn");
        }
        //User Delete Message
        [HttpPost("delete/message/{messageId}")]
        public IActionResult DeleteMessage(int messageId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                Message messageToRemove = _context.Messages
                    .FirstOrDefault(t => t.MessageId == messageId);

                _context.Remove(messageToRemove);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("SignIn");
        }
        //Edit Project
        [HttpGet("edit/project/{projectId}")]
        public IActionResult EditProject(int projectId)
        {
            Project projectToEdit = _context.Projects
                .FirstOrDefault(p => p.ProjectId == projectId);

            // passing it as a ViewModel
            return View(projectToEdit);
        }
        //Update Project
        [HttpPost("update-project")]
        public IActionResult UpdateProject(Project updatedProject) // this is coming from the form
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                var projectToUpdate = _context.Projects
                    .FirstOrDefault(p => p.ProjectId == updatedProject.ProjectId);


                projectToUpdate.Title = updatedProject.Title;
                projectToUpdate.ProjectDescription = updatedProject.ProjectDescription;
                projectToUpdate.ProjectStartDate = updatedProject.ProjectStartDate;
                projectToUpdate.ProjectDueDate = updatedProject.ProjectDueDate;

                _context.SaveChanges();

                return RedirectToAction("ProjectDetails", new { projectId = updatedProject.ProjectId });
            }
            return View("SignIn");
        }
        //User Delete Project
        [HttpPost("delete/project/{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            User currentUser = GetCurrentUser();
            if (currentUser != null)
            {
                Project projectToRemove = _context.Projects
                    .FirstOrDefault(p => p.ProjectId == projectId);
                _context.Remove(projectToRemove);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");

            }
            return View("SignIn");
        }
        //Admin Dashboard View
        //

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

    }
}
