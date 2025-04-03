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
                .Include(s => s.Sessions)
                .Include(g => g.Resources)
                .ThenInclude(r => r.UploadedBy) // Include the user who uploaded the resources  
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
                studyGroup.InviteCode = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
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

        public async Task<IActionResult> Leaderboard(int id)
        {
            var group = await _context.StudyGroups.FindAsync(id);
            if (group == null) return NotFound();

            var sessions = await _context.Sessions
                .Where(s => s.StudyGroupId == id)
                .GroupBy(s => s.CreatedById)
                .Select(g => new { UserId = g.Key, Count = g.Count() })
                .ToListAsync();

            var resources = await _context.Resources
                .Where(r => r.StudyGroupId == id)
                .GroupBy(r => r.UploadedById)
                .Select(g => new { UserId = g.Key, Count = g.Count() })
                .ToListAsync();

            var allUserIds = sessions.Select(s => s.UserId)
                .Union(resources.Select(r => r.UserId))
                .Distinct()
                .ToList();

            var users = await _userManager.Users
                .Where(u => allUserIds.Contains(u.Id))
                .ToListAsync();

            var leaderboard = new List<LeaderboardEntry>();

            foreach (var user in users)
            {
                var sessionCount = sessions.FirstOrDefault(s => s.UserId == user.Id)?.Count ?? 0;
                var resourceCount = resources.FirstOrDefault(r => r.UserId == user.Id)?.Count ?? 0;

                leaderboard.Add(new LeaderboardEntry
                {
                    UserId = user.Id,
                    Email = user.Email,
                    SessionsCreated = sessionCount,
                    ResourcesUploaded = resourceCount
                });
            }

            var viewModel = new GroupLeaderboardViewModel
            {
                GroupId = id,
                GroupName = group.GroupName,
                Entries = leaderboard.OrderByDescending(e => e.TotalScore).ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Members(int id)
        {
            var group = await _context.StudyGroups
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.User)
                .FirstOrDefaultAsync(g => g.StudyGroupId == id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }


    }
}
