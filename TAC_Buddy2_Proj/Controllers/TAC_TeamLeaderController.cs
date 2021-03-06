﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAC_Buddy2_Proj.Data;
using TAC_Buddy2_Proj.Models;
using TAC_Buddy2_Proj.Views.TAC_TeamLeader;
using CoordinateSharp;

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

            if (teamLeaderTeamMateAndEDL.TAC_TeamLeader == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                teamLeaderTeamMateAndEDL.TAC_TeamMates = _context.TAC_TeamMates.Where(t => t.TAC_TeamLeader_ID == teamLeaderTeamMateAndEDL.TAC_TeamLeader.TAC_TeamLeader_ID).ToList();
                teamLeaderTeamMateAndEDL.EDL_Items = _context.EDL_Items.ToList();
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
        public async Task<IActionResult> DeleteTeamMate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAC_TeamMate = await _context.TAC_TeamMates
                .FirstOrDefaultAsync(m => m.TAC_TeamMate_ID == id);
            if (tAC_TeamMate == null)
            {
                return NotFound();
            }

            return View(tAC_TeamMate);
        }

        // POST: TAC_TeamLeader/Delete/5
        [HttpPost, ActionName("DeleteTeamMate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTeamMateConfirmed(int id)
        {
            var tAC_TeamMate = await _context.TAC_TeamMates.FindAsync(id);
            _context.TAC_TeamMates.Remove(tAC_TeamMate);
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
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CreateEDLItemTeamLeader(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEDLItemTeamLeader(EDL_Item eDL_Item, int id)
        { 
                eDL_Item.TAC_TeamLeader_ID = id;
                _context.EDL_Items.Add(eDL_Item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateEDLItemTeamMate(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEDLItemTeamMate(EDL_Item eDL_Item, int id)
        {
            eDL_Item.TAC_TeamMate_ID = id;
            _context.EDL_Items.Add(eDL_Item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditEDLItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eDL_Item = await _context.EDL_Items.FindAsync(id);
            if (eDL_Item == null)
            {
                return NotFound();
            }
            return View(eDL_Item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEDLItem(EDL_Item eDL_Item, int id)
        {

            try
            {
                var EDL_ItemInDB = _context.EDL_Items.Single(e => e.EDL_ID == id);
                EDL_ItemInDB.EDL_Item_Name = eDL_Item.EDL_Item_Name;
                EDL_ItemInDB.EDL_Serial = eDL_Item.EDL_Serial;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TAC_TeamLeader/Delete/5
        public async Task<IActionResult> DeleteEDLItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eDL_Item = await _context.EDL_Items
                .FirstOrDefaultAsync(e => e.EDL_ID == id);
            if (eDL_Item == null)
            {
                return NotFound();
            }

            return View(eDL_Item);
        }

        // POST: TAC_TeamLeader/Delete/5
        [HttpPost, ActionName("DeleteEDLItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEDLItemConfirmed(int id)
        {
            var eDL_Item = await _context.EDL_Items.FindAsync(id);
            _context.EDL_Items.Remove(eDL_Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> VerifyTeamLeaderEDL(int id)
        {
            var teamMember = await _context.TAC_TeamLeaders.FindAsync(id);
            teamMember.EDL_Last_Verified = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> VerifyTeamMateEDL(int id)
        {
            var teamMember = await _context.TAC_TeamMates.FindAsync(id);
            teamMember.EDL_Last_Verified = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Calculators()
        {
            return View();
        }

        public IActionResult GroundNavigationCalculators()
        {
            return View();
        }

        public IActionResult TacticalAirControlCalculators()
        {
            return View();
        }

        public IActionResult SurfaceFireSupportCalculators()
        {
            return View();
        }
        
        public IActionResult FieldMedicineCalculators()
        {
            return View();
        }
        
        public IActionResult DemolitionsCalculators()
        {
            return View();
        }

        public IActionResult CommTemplates()
        {
            return View();
        }
        
        public IActionResult TAC_Map()
        {
            APIKey aPIKey = new APIKey();
            ViewBag.key = aPIKey.googleKey;
            return View();
        }

        [HttpPost]
        public IActionResult MilsToDegrees(string stringMils, string ViewName)
        {
            double mils = Convert.ToDouble(stringMils);
            ViewBag.MilsToDegrees = mils * 0.05625;            
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult DegreesToMils(string stringDegrees, string ViewName)
        {
            double degrees = Convert.ToDouble(stringDegrees);
            ViewBag.DegreesToMils = degrees / 0.05625;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult MetersToFeet(string stringMeters, string ViewName)
        {
            double meters = Convert.ToDouble(stringMeters);
            ViewBag.MetersToFeet = meters * 3.28;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult FeetToMeters(string stringFeet, string ViewName)
        {
            double feet = Convert.ToDouble(stringFeet);
            ViewBag.FeetToMeters = feet / 3.28;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult MilsToMOA(string stringMils, string ViewName)
        {
            double mils = Convert.ToDouble(stringMils);
            ViewBag.MilsToMOA = mils / 3.438;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult MOAToMils(string stringMOA, string ViewName)
        {
            double MOA = Convert.ToDouble(stringMOA);
            ViewBag.MOAToMils = MOA * 3.438;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult MilesToKilometers(string stringMiles, string ViewName)
        {
            double Miles = Convert.ToDouble(stringMiles);
            ViewBag.MilesToKilometers = Miles * 1.609344;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult KilometersToMiles(string stringKilometers, string ViewName)
        {
            double Kilometers = Convert.ToDouble(stringKilometers);
            ViewBag.KilometersToMiles = Kilometers / 1.609344;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult NauticalMilesToKilometers(string stringNauticalMiles, string ViewName)
        {
            double NauticalMiles = Convert.ToDouble(stringNauticalMiles);
            ViewBag.NauticalMilesToKilometers = NauticalMiles * 1.852;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult KilometersToNauticalMiles(string stringKilometers, string ViewName)
        {
            double Kilometers = Convert.ToDouble(stringKilometers);
            ViewBag.KilometersToNauticalMiles = Kilometers * .5399568;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult KilogramsToPounds(string stringKilograms, string ViewName)
        {
            double Kilograms = Convert.ToDouble(stringKilograms);
            ViewBag.KilogramsToPounds = Kilograms * 2.20462262;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult PoundsToKilograms(string stringPounds, string ViewName)
        {
            double Pounds = Convert.ToDouble(stringPounds);
            ViewBag.PoundsToKilograms = Pounds * 0.45359237;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult GramsToOunces(string stringGrams, string ViewName)
        {
            double Grams = Convert.ToDouble(stringGrams);
            ViewBag.GramsToOunces = Grams * 0.03527396;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult OuncesToGrams(string stringOunces, string ViewName)
        {
            double Ounces = Convert.ToDouble(stringOunces);
            ViewBag.OuncesToGrams = Ounces * 28.34952;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult CelsiusToFarenheit(string stringCelsius, string ViewName)
        {
            double Celsius = Convert.ToDouble(stringCelsius);
            ViewBag.CelsiusToFarenheit = (Celsius * 1.8) + 32;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult FarenheitToCelsius(string stringFarenheit, string ViewName)
        {
            double Farenheit = Convert.ToDouble(stringFarenheit);
            ViewBag.FarenheitToCelsius = (Farenheit - 32) / 1.8;
            return View(ViewName);
        }
        
        [HttpPost]
        public IActionResult FeetPerSecondToMetersPerSecond(string stringFPS, string ViewName)
        {
            double FPS = Convert.ToDouble(stringFPS);
            ViewBag.FeetPerSecondToMetersPerSecond = FPS * .3048;
            return View(ViewName);
        }
        
        [HttpPost]
        public IActionResult MetersPerSecondToFeetPerSecond(string stringMPS, string ViewName)
        {
            double MPS = Convert.ToDouble(stringMPS);
            ViewBag.MetersPerSecondToFeetPerSecond = MPS * 3.28084;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult MilesPerGallonToKilometersPerLiter(string stringMPG, string ViewName)
        {
            double MPG = Convert.ToDouble(stringMPG);
            ViewBag.MilesPerGallonToKilometersPerLiter = MPG * 0.4251;
            return View(ViewName);
        }
        
        [HttpPost]
        public IActionResult KilometersPerLiterToMilesPerGallon(string stringKPL, string ViewName)
        {
            double KPL = Convert.ToDouble(stringKPL);
            ViewBag.KilometersPerLiterToMilesPerGallon = KPL * 2.3521;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult YardsToMeters(string stringYards, string ViewName)
        {
            double Yards = Convert.ToDouble(stringYards);
            ViewBag.YardsToMeters = Yards * .9144;
            return View(ViewName);
        }

        [HttpPost]
        public IActionResult MetersToYards(string stringMeters, string ViewName)
        {
            double Meters = Convert.ToDouble(stringMeters);
            ViewBag.MetersToYards = Meters * 1.093613;
            return View(ViewName);
        }
    }    
}
