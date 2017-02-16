using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechAcademyJobBoard.Data;
using TechAcademyJobBoard.Models.JsonJobModel;

namespace TechAcademyJobBoard.Controllers
{
    public class JsonJobsController : Controller
    {
        private readonly TAJobBoardDbContext _context;

        public JsonJobsController(TAJobBoardDbContext context)
        {
            _context = context;    
        }

        // GET: JsonJobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.JsonJob.ToListAsync());
        }

        // GET: JsonJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jsonJob = await _context.JsonJob.SingleOrDefaultAsync(m => m.ID == id);
            if (jsonJob == null)
            {
                return NotFound();
            }

            return View(jsonJob);
        }

        // GET: JsonJobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JsonJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplicationLink,Company,DatePosted,Experience,Hours,JobID,JobTitle,LanguagesUsed,Location,Salary")] JsonJob jsonJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jsonJob);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jsonJob);
        }

        // GET: JsonJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jsonJob = await _context.JsonJob.SingleOrDefaultAsync(m => m.ID == id);
            if (jsonJob == null)
            {
                return NotFound();
            }
            return View(jsonJob);
        }

        // POST: JsonJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationLink,Company,DatePosted,Experience,Hours,JobID,JobTitle,LanguagesUsed,Location,Salary")] JsonJob jsonJob)
        {
            if (id != jsonJob.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jsonJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JsonJobExists(jsonJob.ID))
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
            return View(jsonJob);
        }

        // GET: JsonJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jsonJob = await _context.JsonJob.SingleOrDefaultAsync(m => m.ID == id);
            if (jsonJob == null)
            {
                return NotFound();
            }

            return View(jsonJob);
        }

        // POST: JsonJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jsonJob = await _context.JsonJob.SingleOrDefaultAsync(m => m.ID == id);
            _context.JsonJob.Remove(jsonJob);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JsonJobExists(int id)
        {
            return _context.JsonJob.Any(e => e.ID == id);
        }
    }
}
