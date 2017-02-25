using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoardMVC.Data;
using JobBoardMVC.Models;
using System;

namespace JobBoardMVC.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobBoardMVCDbContext _context;

        public JobsController(JobBoardMVCDbContext context)
        {
            _context = context;
        }

        // GET: Jobs
        // Include LINQ query to allow search
        public async Task<IActionResult> Index(string searchString)
        {
            var jobs = from j in _context.Job
                       select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(j => j.JobTitle.Contains(searchString));
            }


            return View(await _context.Job.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplicationLink,Company,DatePosted,Experience,Hours,JobID,JobTitle,LanguagesUsed,Location,Salary")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationLink,Company,DatePosted,Experience,Hours,JobID,JobTitle,LanguagesUsed,Location,Salary")] Job job)
        {
            if (id != job.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.ID))
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
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.ID == id);
        }
    }
}
