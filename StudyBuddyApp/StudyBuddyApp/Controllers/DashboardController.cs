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

            // Only joined groups
            var groups = await _context.GroupMembers
                .Where(m => m.UserId == userId)
                .Include(m => m.StudyGroup)
                .Select(m => m.StudyGroup)
                .ToListAsync();

            // Upcoming sessions from joined groups only

            var upcomingSessions = await _context.Sessions
                .Where(s => s.StartTime >= DateTime.UtcNow &&
                            groups.Select(g => g.StudyGroupId).Contains(s.StudyGroupId))
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
