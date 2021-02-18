using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ViewModel.Models;

namespace ViewModel.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Home()
        {
            string[] messages = new string[]
        {
            "Hello there, this is a message to say -- you did it! Now get back to work. Thank you.",
        };


            return View(messages);
        }

        [HttpGet("/numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 10, 43, 5 };
            return View(numbers);
        }

        [HttpGet("/user")]

        public IActionResult Person()
        {
            var user = new User
            {
                FirstName = "Arty",
                LastName = "Huyck"
            };

            return View(user);
        }

        [HttpGet("/users")]
        public IActionResult Users()
        {
            var users = new User[]
            {
                new User
                {
                    FirstName = "Apollo",
                    LastName = "Huyck"
                },
                new User
                {
                    FirstName = "Cheyenne",
                    LastName = "Deal"
                },
                new User
                {
                    FirstName = "Sage",
                    LastName = "Deal"
                }
            };


            return View(users);
        }
    }
}