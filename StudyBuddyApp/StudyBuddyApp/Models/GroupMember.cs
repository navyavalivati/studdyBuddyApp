namespace StudyBuddyApp.Models
{
    public class GroupMember
    {
        public int Id { get; set; }
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.Now;
    }

}
