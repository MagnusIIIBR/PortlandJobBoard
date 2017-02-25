using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Data;
using JobBoard.Models;

namespace JobBoard.Controllers
{
    public class CompanyIDsController : Controller
    {
        private readonly JobBoardDbContext _context;

        public CompanyIDsController(JobBoardDbContext context)
        {
            _context = context;    
        }

        // GET: CompanyIDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyID.ToListAsync());
        }

        // GET: CompanyIDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyID = await _context.CompanyID.SingleOrDefaultAsync(m => m.ID == id);
            if (companyID == null)
            {
                return NotFound();
            }

            return View(companyID);
        }

        // GET: CompanyIDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Location,Name,PhoneNumber,Website")] CompanyID companyID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyID);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyID);
        }

        // GET: CompanyIDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyID = await _context.CompanyID.SingleOrDefaultAsync(m => m.ID == id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // POST: CompanyIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Location,Name,PhoneNumber,Website")] CompanyID companyID)
        {
            if (id != companyID.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyID);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyIDExists(companyID.ID))
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
            return View(companyID);
        }

        // GET: CompanyIDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyID = await _context.CompanyID.SingleOrDefaultAsync(m => m.ID == id);
            if (companyID == null)
            {
                return NotFound();
            }

            return View(companyID);
        }

        // POST: CompanyIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyID = await _context.CompanyID.SingleOrDefaultAsync(m => m.ID == id);
            _context.CompanyID.Remove(companyID);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyIDExists(int id)
        {
            return _context.CompanyID.Any(e => e.ID == id);
        }
    }
}
