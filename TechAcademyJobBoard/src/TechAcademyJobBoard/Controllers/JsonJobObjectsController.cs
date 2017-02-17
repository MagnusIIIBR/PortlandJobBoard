using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechAcademyJobBoard.Data;
using TechAcademyJobBoard.Models;

namespace TechAcademyJobBoard.Controllers
{
    public class JsonJobObjectsController : Controller
    {
        private readonly TAJobBoardDbContext _context;

        public JsonJobObjectsController(TAJobBoardDbContext context)
        {
            _context = context;    
        }

        // GET: JsonJobObjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.JsonJobObject.ToListAsync());
        }

        // GET: JsonJobObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jsonJobObject = await _context.JsonJobObject.SingleOrDefaultAsync(m => m.ID == id);
            if (jsonJobObject == null)
            {
                return NotFound();
            }

            return View(jsonJobObject);
        }

        // GET: JsonJobObjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JsonJobObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] JsonJobObject jsonJobObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jsonJobObject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jsonJobObject);
        }

        // GET: JsonJobObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jsonJobObject = await _context.JsonJobObject.SingleOrDefaultAsync(m => m.ID == id);
            if (jsonJobObject == null)
            {
                return NotFound();
            }
            return View(jsonJobObject);
        }

        // POST: JsonJobObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] JsonJobObject jsonJobObject)
        {
            if (id != jsonJobObject.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jsonJobObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JsonJobObjectExists(jsonJobObject.ID))
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
            return View(jsonJobObject);
        }

        // GET: JsonJobObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jsonJobObject = await _context.JsonJobObject.SingleOrDefaultAsync(m => m.ID == id);
            if (jsonJobObject == null)
            {
                return NotFound();
            }

            return View(jsonJobObject);
        }

        // POST: JsonJobObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jsonJobObject = await _context.JsonJobObject.SingleOrDefaultAsync(m => m.ID == id);
            _context.JsonJobObject.Remove(jsonJobObject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JsonJobObjectExists(int id)
        {
            return _context.JsonJobObject.Any(e => e.ID == id);
        }
    }
}
