using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Features.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Spange.Models;
using System.Linq;
using System.Security.Claims;

namespace Spange.Controllers
{
    [Authorize(Roles = "Player")]
    public class PlayersController : Controller
    {
        private SpangeDbContext _context;
        private ApplicationDbContext _userdb;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayersController(SpangeDbContext context, UserManager<ApplicationUser> userManager, ApplicationDbContext userdb)
        {
            _context = context;
            _userManager = userManager;
            _userdb = userdb;
        }

        // GET: Players
        public IActionResult Index()
        {
            var userId = User.GetUserId();
            var user = _userdb.Users.FirstOrDefault(u => u.Id == userId);
            ViewData["UserName"] = user.UserName;
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
            ViewData["UserName"] = User.GetUserName();
            player.Inventory = _context.Gears.Join(_context.Inventories.Where(i => i.PlayerId == id).ToList(),
                g => g.GearId,
                i => i.GearId,
                (o, i) => o).ToList();
            ViewBag.AllGear = _context.Gears.ToList().Except(player.Inventory);

            return View(player);
        }

        // Post: Players/Jackgear
        [HttpPost]
        public IActionResult JackGear(int gearId, int playerId)
        {
            Inventory playerInventory = new Inventory();
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);
            playerInventory.GearId = gearId;
            playerInventory.PlayerId = playerId;
            _context.Inventories.Add(playerInventory);
            _context.SaveChanges();
            ViewData["UserName"] = User.GetUserName();
            player.Inventory = _context.Gears.Join(_context.Inventories.Where(i => i.PlayerId == playerId).ToList(),
                g => g.GearId,
                i => i.GearId,
                (o, i) => o).ToList();
            ViewBag.AllGear = _context.Gears.ToList().Except(player.Inventory);
            return View("Details", player);
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

            ViewBag.Inventory = _context.Gears.Join(_context.Inventories.Where(i => i.PlayerId == player.PlayerId).ToList(),
                g => g.GearId,
                i => i.GearId,
                (o, i) => o).ToList();
            ViewBag.AllGear = _context.Gears.ToList();

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