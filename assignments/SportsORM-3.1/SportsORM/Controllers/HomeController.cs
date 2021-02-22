using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();

            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(l => !l.Sport.Contains("Football"))
                .ToList();

            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasTeams = _context.Teams
                .Where(t => t.Location == "Dallas")
                .ToList();

            ViewBag.RaptorsTeams = _context.Teams
            .Where(t => t.TeamName.Contains("Raptors"))
            .ToList();

            ViewBag.CityTeams = _context.Teams
            .Where(t => t.Location.Contains("City"))
            .ToList();

            ViewBag.TTeams = _context.Teams
            .Where(t => t.TeamName.StartsWith("t"))
            .ToList();

            ViewBag.SortedTeams = _context.Teams
            .OrderBy(t => t.TeamName)
            .ToList();

            ViewBag.SortedDescendingTeams = _context.Teams
            .OrderByDescending(t => t.TeamName)
            .ToList();

            ViewBag.lNameCooper = _context.Players
            .Where(p => p.LastName == ("Cooper"))
            .ToList();

            ViewBag.fNameJoshua = _context.Players
            .Where(p => p.FirstName == ("Joshua"))
            .ToList();

            ViewBag.lNameCooperNoJoshua = _context.Players
            .Where(p => p.LastName == ("Cooper") && p.FirstName != ("Joshua"))
            .ToList();

            ViewBag.AlexanderAndWyatt = _context.Players
            .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt")
            .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.AtlanticConferenceTeams = _context.Teams
                .Include(t => t.CurrLeague)
                .Where(t => t.CurrLeague.Name == "Atlantic Soccer Conference");

            ViewBag.BostonPenguinsPlayers = _context.Teams
                .Include(t => t.CurrentPlayers)
                .FirstOrDefault(t => t.TeamName == "Penguins");

            ViewBag.IntCollegiateBaseballConfPlayers = _context.Teams
                .Include(t => t.CurrentPlayers)
                .FirstOrDefault(t => t.CurrLeague.Name == "International Collegiate Baseball Conference");

            ViewBag.USAmateurFootballPlayers = _context.Teams
                .Include(t => t.CurrentPlayers)
                .FirstOrDefault(t => t.CurrLeague.Name == "American Conference of Amateur Football");
            

            ViewBag.FootballPlayers = _context.Players;

            ViewBag.TeamsWithSophia = _context.Teams
                .Include(t => t.CurrentPlayers)
                .Where(t => t.CurrentPlayers.Any(p => p.FirstName == "Sophia"));

            ViewBag.LeaguesWithSophia = _context.Leagues
                .Include(l => l.Teams)
                .Where(t => t.Teams.Any(p => p.CurrentPlayers.Any(p => p.FirstName == "Sophia")))
                .ToList();

            ViewBag.TeamsWithFlores = _context.Players
                .Include(p => p.CurrentTeam)
                .Where(p => p.LastName == "Flores");

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}