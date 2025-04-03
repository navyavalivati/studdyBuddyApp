using StudyBuddyApp.Models;

namespace StudyBuddyApp.ViewModels
{
    public class DashboardViewModel
    {
        public List<StudyGroup> JoinedGroups { get; set; }
        public List<Session> UpcomingSessions { get; set; }
    }
}
