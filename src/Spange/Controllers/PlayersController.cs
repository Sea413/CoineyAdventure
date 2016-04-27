using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Http.Features.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Spange.Models;
using Microsoft.AspNet.Authorization;

namespace Spange.Controllers
{
    public class PlayersController : Controller
    {
        private SpangeDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public PlayersController(SpangeDbContext context, UserManager<ApplicationUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Players
        public IActionResult Index()
        {
            return View(_context.Players.ToList());
        }

        // GET: Players/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Player player = _context.Players.Single(m => m.PlayerId == id);
            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                player.UserId = User.GetUserId();
                var user = _userManager.Users.FirstOrDefault(u => u.Id == player.UserId);
                var thing = _userManager.AddToRoleAsync(user, "Player").Result;
                _context.Players.Add(player);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Edit/5
        [Authorize(Roles="Player")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Player player = _context.Players.Single(m => m.PlayerId == id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Update(player);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Player player = _context.Players.Single(m => m.PlayerId == id);
            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Player player = _context.Players.Single(m => m.PlayerId == id);
            _context.Players.Remove(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
