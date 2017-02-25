using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoardMVC.Data;
using JobBoardMVC.Models;

namespace JobBoardMVC.Controllers
{
    public class PlacesController : Controller
    {
        private readonly JobBoardMVCDbContext _context;

        public PlacesController(JobBoardMVCDbContext context)
        {
            _context = context;    
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            return View(await _context.Place.ToListAsync());
        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place.SingleOrDefaultAsync(m => m.ID == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location")] Place place)
        {
            if (ModelState.IsValid)
            {
                _context.Add(place);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place.SingleOrDefaultAsync(m => m.ID == id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location")] Place place)
        {
            if (id != place.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Place.SingleOrDefaultAsync(m => m.ID == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place = await _context.Place.SingleOrDefaultAsync(m => m.ID == id);
            _context.Place.Remove(place);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlaceExists(int id)
        {
            return _context.Place.Any(e => e.ID == id);
        }
    }
}
