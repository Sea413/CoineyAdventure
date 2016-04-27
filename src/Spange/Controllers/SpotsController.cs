using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Spange.Models;

namespace Spange.Controllers
{
    public class SpotsController : Controller
    {
        private SpangeDbContext _context;

        public SpotsController(SpangeDbContext context)
        {
            _context = context;    
        }

        // GET: Spots
        public IActionResult Index()
        {
            return View(_context.Spots.ToList());
        }

        // GET: Spots/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Spot spot = _context.Spots.Single(m => m.SpotId == id);
            if (spot == null)
            {
                return HttpNotFound();
            }

            return View(spot);
        }

        // GET: Spots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spots/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Spot spot)
        {
            if (ModelState.IsValid)
            {
                _context.Spots.Add(spot);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spot);
        }

        // GET: Spots/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Spot spot = _context.Spots.Single(m => m.SpotId == id);
            if (spot == null)
            {
                return HttpNotFound();
            }
            return View(spot);
        }

        // POST: Spots/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Spot spot)
        {
            if (ModelState.IsValid)
            {
                _context.Update(spot);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spot);
        }

        // GET: Spots/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Spot spot = _context.Spots.Single(m => m.SpotId == id);
            if (spot == null)
            {
                return HttpNotFound();
            }

            return View(spot);
        }

        // POST: Spots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Spot spot = _context.Spots.Single(m => m.SpotId == id);
            _context.Spots.Remove(spot);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
