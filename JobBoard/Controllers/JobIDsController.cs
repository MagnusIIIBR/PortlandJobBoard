using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Data;
using JobBoard.Models.JobModel;

namespace JobBoard.Controllers
{
    public class JobIDsController : Controller
    {
        private readonly JobBoardDbContext _context;

        public JobIDsController(JobBoardDbContext context)
        {
            _context = context;    
        }

        // GET: JobIDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobID.ToListAsync());
        }

        // GET: JobIDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobID = await _context.JobID.SingleOrDefaultAsync(m => m.ID == id);
            if (jobID == null)
            {
                return NotFound();
            }

            return View(jobID);
        }

        // GET: JobIDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Company,Contract,FullTime,JobTitle,Location,PartTime")] JobID jobID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobID);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobID);
        }

        // GET: JobIDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobID = await _context.JobID.SingleOrDefaultAsync(m => m.ID == id);
            if (jobID == null)
            {
                return NotFound();
            }
            return View(jobID);
        }

        // POST: JobIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Company,Contract,FullTime,JobTitle,Location,PartTime")] JobID jobID)
        {
            if (id != jobID.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobID);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobIDExists(jobID.ID))
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
            return View(jobID);
        }

        // GET: JobIDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobID = await _context.JobID.SingleOrDefaultAsync(m => m.ID == id);
            if (jobID == null)
            {
                return NotFound();
            }

            return View(jobID);
        }

        // POST: JobIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobID = await _context.JobID.SingleOrDefaultAsync(m => m.ID == id);
            _context.JobID.Remove(jobID);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobIDExists(int id)
        {
            return _context.JobID.Any(e => e.ID == id);
        }
    }
}
