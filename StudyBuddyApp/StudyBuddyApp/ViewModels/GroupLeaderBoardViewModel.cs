namespace StudyBuddyApp.ViewModels
{
    public class LeaderboardEntry
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public int SessionsCreated { get; set; }
        public int ResourcesUploaded { get; set; }
        public int TotalScore => SessionsCreated + ResourcesUploaded;
    }

    public class GroupLeaderboardViewModel
    {
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        public List<LeaderboardEntry> Entries { get; set; }
    }
}
