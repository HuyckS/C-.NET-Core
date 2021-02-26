using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using BankAccount.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser(User newUser)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email in use -- please register with a different email.");
                return View("Register");
            }
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("ViewAccount");
            }
            return View("Register");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login-user")]
        public IActionResult LoginUser(LoginUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                var userLogged = _context.Users
                    .FirstOrDefault(u => u.Email == userSubmission.Email);

                if (userLogged == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email / Password");
                    return View("Login");
                }

                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userLogged.Password, userSubmission.Password);

                if (result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email / Password");
                    return View("Login");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", userLogged.UserId);
                    return RedirectToAction("ViewAccount");
                }
            }
            return View("Login");
        }

        [HttpGet("account")]
        public IActionResult ViewAccount()
        {
            int? signedIn = HttpContext.Session.GetInt32("UserId");
            if (signedIn > 0)
            {
                User currentUser = _context.Users
                    .Include(u => u.UserHistory)
                    .FirstOrDefault(u => u.UserId == signedIn);

                ViewBag.History = currentUser.UserHistory.OrderByDescending(t => t.CreatedAt);
                ViewBag.CurrentUser = currentUser;

                return View();
            }

            return View("Login");
        }

        [HttpPost("create-transaction")]
        public IActionResult CreateTransaction(Transaction newTransaction)
        {
            int? signedIn = HttpContext.Session.GetInt32("UserId");
            if (signedIn > 0)
            {
                var account = _context.Users.FirstOrDefault(u => u.UserId == (int)signedIn);

                if (account.CurrentBalance + newTransaction.Amount < 0)
                {
                    ModelState.AddModelError("Amount", "Transaction cannot be completed -- insufficient funds");
                    ViewBag.currentUser = _context.Users
                    .Include(u => u.UserHistory)
                    .FirstOrDefault(u => u.UserId == signedIn);


                    return View("ViewAccount");
                }

                newTransaction.UserId = account.UserId;

                if (ModelState.IsValid)
                {
                    var result = account.CurrentBalance + newTransaction.Amount;
                    account.CurrentBalance = result;
                    account.UpdatedAt = DateTime.Now;
                    _context.Transactions.Add(newTransaction); //create the transaction in the db
                    _context.SaveChanges();
                    return RedirectToAction("ViewAccount");
                }
                return View("ViewAccount");
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
