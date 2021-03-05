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

            TeamLeaderTeamMateAndEDL teamLeaderTeamMateAndEDL = new TeamLeaderTeamMateAndEDL();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            teamLeaderTeamMateAndEDL.TAC_TeamLeader = _context.TAC_TeamLeaders.Where(t => t.IdentityUserId == userId).SingleOrDefault();
            teamLeaderTeamMateAndEDL.TAC_TeamMates = _context.TAC_TeamMates.Where(t => t.TAC_TeamLeader_ID == teamLeaderTeamMateAndEDL.TAC_TeamLeader.TAC_TeamLeader_ID).ToList();
            teamLeaderTeamMateAndEDL.EDL_Items = _context.EDL_Items.ToList();

            if (teamLeaderTeamMateAndEDL.TAC_TeamLeader == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(teamLeaderTeamMateAndEDL);
            }
        }

        // GET: TAC_TeamLeader/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Edit(int? id)
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
        public IActionResult Edit(TAC_TeamLeader tAC_TeamLeader)
        {
            try
            {
                var TeamLeaderInDB = _context.TAC_TeamLeaders.Single(t => t.TAC_TeamLeader_ID == tAC_TeamLeader.TAC_TeamLeader_ID);
                TeamLeaderInDB.Rank = tAC_TeamLeader.Rank;
                TeamLeaderInDB.FirstName = tAC_TeamLeader.FirstName;
                TeamLeaderInDB.LastName = tAC_TeamLeader.LastName;
                TeamLeaderInDB.EDIPI_DoD_ID = tAC_TeamLeader.EDIPI_DoD_ID;
                TeamLeaderInDB.Billet = tAC_TeamLeader.Billet;
                TeamLeaderInDB.MOS_designator = tAC_TeamLeader.MOS_designator;
                TeamLeaderInDB.EDL_Last_Verified = tAC_TeamLeader.EDL_Last_Verified;
                TeamLeaderInDB.ZAP_Number = tAC_TeamLeader.ZAP_Number;
                
                _context.SaveChanges();
                // return RedirectToAction("Index", "Developer");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TAC_TeamLeader/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tAC_TeamLeader = await _context.TAC_TeamLeaders.FindAsync(id);
            _context.TAC_TeamLeaders.Remove(tAC_TeamLeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAC_TeamLeaderExists(int id)
        {
            return _context.TAC_TeamLeaders.Any(e => e.TAC_TeamLeader_ID == id);
        }

        //GET: TAC_TeamLeader/Edit/5
        public async Task<IActionResult> EditTeamMate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teamMate = await _context.TAC_TeamMates.FindAsync(id);
            if (teamMate == null)
            {
                return NotFound();
            }
            return View(teamMate);
        }

        // POST: TAC_TeamLeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTeamMate(TAC_TeamMate tAC_TeamMate)
        {
            try
            {
                var TeamMateInDB = _context.TAC_TeamMates.Single(t => t.TAC_TeamMate_ID == tAC_TeamMate.TAC_TeamMate_ID);
                TeamMateInDB.Rank = tAC_TeamMate.Rank;
                TeamMateInDB.FirstName = tAC_TeamMate.FirstName;
                TeamMateInDB.LastName = tAC_TeamMate.LastName;
                TeamMateInDB.EDIPI_DoD_ID = tAC_TeamMate.EDIPI_DoD_ID;
                TeamMateInDB.Billet = tAC_TeamMate.Billet;
                TeamMateInDB.MOS_designator = tAC_TeamMate.MOS_designator;
                TeamMateInDB.EDL_Last_Verified = tAC_TeamMate.EDL_Last_Verified;
                TeamMateInDB.ZAP_Number = tAC_TeamMate.ZAP_Number;

                _context.SaveChanges();
                // return RedirectToAction("Index", "Developer");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CreateTeamMate(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTeamMate(TAC_TeamMate tAC_TeamMate, int id)
        {
            try
            {
                tAC_TeamMate.TAC_TeamLeader_ID = id;
                _context.TAC_TeamMates.Add(tAC_TeamMate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));


                //job.EmployerId = id;

                //_context.Jobs.Add(job);
                //_context.SaveChanges();
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }    
}
