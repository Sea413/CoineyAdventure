using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Spange.Models;

namespace Spange.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private SpangeDbContext _spangeContext;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SpangeDbContext spangeContext)
        {
            _context = context;
            _userManager = userManager;
            _spangeContext = spangeContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Play()
        {
        
            var user = _userManager.Users.FirstOrDefault(u => u.Id == User.GetUserId());
            if (_userManager.IsInRoleAsync(user, "Player").Result)
            {
                return RedirectToAction("Index", "Game");
            }
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                player.UserId = User.GetUserId();
                var user = _userManager.Users.FirstOrDefault(u => u.Id == player.UserId);
                var thing = _userManager.AddToRoleAsync(user, "Player").Result;
                _spangeContext.Players.Add(player);
                _spangeContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
