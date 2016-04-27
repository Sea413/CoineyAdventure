using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Spange.Models;

namespace Spange.Controllers
{
    public class GearsController : Controller
    {
        private SpangeDbContext _context;

        public GearsController(SpangeDbContext context)
        {
            _context = context;    
        }

        // GET: Gears
        public IActionResult Index()
        {
            return View(_context.Gears.ToList());
        }

        // GET: Gears/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Gear gear = _context.Gears.Single(m => m.GearId == id);
            if (gear == null)
            {
                return HttpNotFound();
            }

            return View(gear);
        }

        // GET: Gears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gears/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Gears.Add(gear);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gear);
        }

        // GET: Gears/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Gear gear = _context.Gears.Single(m => m.GearId == id);
            if (gear == null)
            {
                return HttpNotFound();
            }
            return View(gear);
        }

        // POST: Gears/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Update(gear);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gear);
        }

        // GET: Gears/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Gear gear = _context.Gears.Single(m => m.GearId == id);
            if (gear == null)
            {
                return HttpNotFound();
            }

            return View(gear);
        }

        // POST: Gears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Gear gear = _context.Gears.Single(m => m.GearId == id);
            _context.Gears.Remove(gear);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
