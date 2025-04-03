using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyBuddyApp.Models.StudyBuddyApp.Models;
using StudyBuddyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace StudyBuddyApp.Controllers
{
    public class JoinController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JoinController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string inviteCode)
        {
            var userId = _userManager.GetUserId(User);

            var group = await _context.StudyGroups.FirstOrDefaultAsync(g => g.InviteCode == inviteCode);
            if (group == null)
            {
                TempData["Error"] = "Invalid invite code.";
                return View();
            }

            var alreadyMember = await _context.GroupMembers
                .AnyAsync(m => m.StudyGroupId == group.StudyGroupId && m.UserId == userId);

            if (alreadyMember)
            {
                TempData["Info"] = "You're already a member of this group.";
                return RedirectToAction("Details", "StudyGroups", new { id = group.StudyGroupId });
            }

            var member = new GroupMember
            {
                StudyGroupId = group.StudyGroupId,
                UserId = userId,
                JoinedAt = DateTime.UtcNow
            };

            _context.GroupMembers.Add(member);
            await _context.SaveChangesAsync();

            TempData["Success"] = "You have successfully joined the group!";
            return RedirectToAction("Details", "StudyGroups", new { id = group.StudyGroupId });
        }
    }

}
