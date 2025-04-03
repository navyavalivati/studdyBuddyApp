using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyBuddyApp.Models.StudyBuddyApp.Models;
using StudyBuddyApp.Models;
using Microsoft.EntityFrameworkCore;
using StudyBuddyApp.ViewModels;

namespace StudyBuddyApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var groups = await _context.GroupMembers
                .Where(m => m.UserId == userId)
                .Include(m => m.StudyGroup)
                .Select(m => m.StudyGroup)
                .ToListAsync();

            var upcomingSessions = await _context.Sessions
                .Where(s => groups.Select(g => g.StudyGroupId).Contains(s.StudyGroupId) && s.StartTime >= DateTime.UtcNow)
                .Include(s => s.StudyGroup)
                .OrderBy(s => s.StartTime)
                .ToListAsync();

            var model = new DashboardViewModel
            {
                JoinedGroups = groups,
                UpcomingSessions = upcomingSessions
            };

            return View(model);
        }
    }

}
