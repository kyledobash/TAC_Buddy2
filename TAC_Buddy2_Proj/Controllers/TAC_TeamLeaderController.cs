using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAC_Buddy2_Proj.Data;
using TAC_Buddy2_Proj.Models;

namespace TAC_Buddy2_Proj.Controllers
{
    public class TAC_TeamLeaderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TAC_TeamLeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TAC_TeamLeader
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var teamLeader = _context.TAC_TeamLeaders.Where(t => t.IdentityUserId == userId).SingleOrDefault();
            if (teamLeader == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View();
            }
        }

        // GET: TAC_TeamLeader/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAC_TeamLeader = await _context.TAC_TeamLeaders
                .Include(t => t.IdentityUser)
                .FirstOrDefaultAsync(m => m.TAC_TeamLeader_ID == id);
            if (tAC_TeamLeader == null)
            {
                return NotFound();
            }

            return View(tAC_TeamLeader);
        }

        // GET: TAC_TeamLeader/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TAC_TeamLeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Rank,FirstName,LastName,EDIPI_DoD_ID,Billet,MOS_designator,EDL_Last_Verified,ZAP_Number")] TAC_TeamLeader tAC_TeamLeader)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            tAC_TeamLeader.IdentityUserId = userId;
            _context.Add(tAC_TeamLeader);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: TAC_TeamLeader/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAC_TeamLeader = await _context.TAC_TeamLeaders.FindAsync(id);
            if (tAC_TeamLeader == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tAC_TeamLeader.IdentityUserId);
            return View(tAC_TeamLeader);
        }

        // POST: TAC_TeamLeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double id, [Bind("TAC_TeamLeader_ID,IdentityUserId,Rank,FirstName,LastName,EDIPI_DoD_ID,Billet,MOS_designator,EDL_Last_Verified,ZAP_Number")] TAC_TeamLeader tAC_TeamLeader)
        {
            if (id != tAC_TeamLeader.TAC_TeamLeader_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAC_TeamLeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAC_TeamLeaderExists(tAC_TeamLeader.TAC_TeamLeader_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", tAC_TeamLeader.IdentityUserId);
            return View(tAC_TeamLeader);
        }

        // GET: TAC_TeamLeader/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAC_TeamLeader = await _context.TAC_TeamLeaders
                .Include(t => t.IdentityUser)
                .FirstOrDefaultAsync(m => m.TAC_TeamLeader_ID == id);
            if (tAC_TeamLeader == null)
            {
                return NotFound();
            }

            return View(tAC_TeamLeader);
        }

        // POST: TAC_TeamLeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double id)
        {
            var tAC_TeamLeader = await _context.TAC_TeamLeaders.FindAsync(id);
            _context.TAC_TeamLeaders.Remove(tAC_TeamLeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAC_TeamLeaderExists(double id)
        {
            return _context.TAC_TeamLeaders.Any(e => e.TAC_TeamLeader_ID == id);
        }
    }
}
