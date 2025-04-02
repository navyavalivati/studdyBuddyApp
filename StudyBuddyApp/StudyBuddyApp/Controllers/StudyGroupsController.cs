using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddyApp.Models;
using StudyBuddyApp.Models.StudyBuddyApp.Models;
using StudyBuddyApp.ViewModels;

namespace StudyBuddyApp.Controllers
{
    public class StudyGroupsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudyGroupsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StudyGroups
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.StudyGroups.Include(s => s.CreatedBy);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StudyGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups
                .Include(s => s.CreatedBy)
                .FirstOrDefaultAsync(m => m.StudyGroupId == id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            return View(studyGroup);
        }

        // GET: StudyGroups/Create
        public IActionResult Create()
        {
            ViewData["CreatedById"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: StudyGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudyGroup studyGroup)
        {
            
            ModelState.Remove("CreatedBy");
            ModelState.Remove("CreatedById");

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                if (userId == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }

                studyGroup.CreatedById = userId;
                _context.Add(studyGroup);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Study group created successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(studyGroup);
        }



        // GET: StudyGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups.FindAsync(id);
            if (studyGroup == null)
            {
                return NotFound();
            }
            //ViewData["CreatedById"] = new SelectList(_context.Set<User>(), "UserId", "UserId", studyGroup.CreatedById);
            return View(studyGroup);
        }

        // POST: StudyGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudyGroupId,GroupName,Description,Subject,CreatedById")] StudyGroup studyGroup)
        {
            if (id != studyGroup.StudyGroupId)
            {
                return NotFound();
            }
            ModelState.Remove("CreatedBy");
            ModelState.Remove("CreatedById");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyGroupExists(studyGroup.StudyGroupId))
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
            ViewData["CreatedById"] = new SelectList(_context.Set<User>(), "UserId", "UserId", studyGroup.CreatedById);
            return View(studyGroup);
        }

        // GET: StudyGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyGroup = await _context.StudyGroups
                .Include(s => s.CreatedBy)
                .FirstOrDefaultAsync(m => m.StudyGroupId == id);
            if (studyGroup == null)
            {
                return NotFound();
            }

            return View(studyGroup);
        }

        // POST: StudyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyGroup = await _context.StudyGroups.FindAsync(id);
            if (studyGroup != null)
            {
                _context.StudyGroups.Remove(studyGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyGroupExists(int id)
        {
            return _context.StudyGroups.Any(e => e.StudyGroupId == id);
        }
    }
}
