using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Models;

namespace JobBoard.Data
{
    public class UserIDsController : Controller
    {
        private readonly JobBoardDbContext _context;

        public UserIDsController(JobBoardDbContext context)
        {
            _context = context;    
        }

        // GET: UserIDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserID.ToListAsync());
        }

        // GET: UserIDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userID = await _context.UserID.SingleOrDefaultAsync(m => m.ID == id);
            if (userID == null)
            {
                return NotFound();
            }

            return View(userID);
        }

        // GET: UserIDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,Experience,FirstName,Languages,LastName")] UserID userID)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userID);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userID);
        }

        // GET: UserIDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userID = await _context.UserID.SingleOrDefaultAsync(m => m.ID == id);
            if (userID == null)
            {
                return NotFound();
            }
            return View(userID);
        }

        // POST: UserIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,Experience,FirstName,Languages,LastName")] UserID userID)
        {
            if (id != userID.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userID);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserIDExists(userID.ID))
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
            return View(userID);
        }

        // GET: UserIDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userID = await _context.UserID.SingleOrDefaultAsync(m => m.ID == id);
            if (userID == null)
            {
                return NotFound();
            }

            return View(userID);
        }

        // POST: UserIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userID = await _context.UserID.SingleOrDefaultAsync(m => m.ID == id);
            _context.UserID.Remove(userID);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserIDExists(int id)
        {
            return _context.UserID.Any(e => e.ID == id);
        }
    }
}
