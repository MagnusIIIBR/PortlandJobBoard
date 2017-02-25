using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Data;
using JobBoard.Models.PlaceModel;

namespace JobBoard.Controllers
{
    public class PlaceIDsController : Controller
    {
        private readonly JobBoardDbContext _context;

        public PlaceIDsController(JobBoardDbContext context)
        {
            _context = context;    
        }

        // GET: PlaceIDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlaceID.ToListAsync());
        }

        // GET: PlaceIDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeID = await _context.PlaceID.SingleOrDefaultAsync(m => m.ID == id);
            if (placeID == null)
            {
                return NotFound();
            }

            return View(placeID);
        }

        // GET: PlaceIDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlaceIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location")] PlaceID placeID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placeID);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(placeID);
        }

        // GET: PlaceIDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeID = await _context.PlaceID.SingleOrDefaultAsync(m => m.ID == id);
            if (placeID == null)
            {
                return NotFound();
            }
            return View(placeID);
        }

        // POST: PlaceIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location")] PlaceID placeID)
        {
            if (id != placeID.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placeID);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceIDExists(placeID.ID))
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
            return View(placeID);
        }

        // GET: PlaceIDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placeID = await _context.PlaceID.SingleOrDefaultAsync(m => m.ID == id);
            if (placeID == null)
            {
                return NotFound();
            }

            return View(placeID);
        }

        // POST: PlaceIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placeID = await _context.PlaceID.SingleOrDefaultAsync(m => m.ID == id);
            _context.PlaceID.Remove(placeID);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlaceIDExists(int id)
        {
            return _context.PlaceID.Any(e => e.ID == id);
        }
    }
}
