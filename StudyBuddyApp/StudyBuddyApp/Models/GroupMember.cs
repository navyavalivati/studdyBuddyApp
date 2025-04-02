namespace StudyBuddyApp.Models
{
    public class GroupMember
    {
        public int GroupMemberId { get; set; } // Primary key
        public int GroupId { get; set; } // Foreign key to StudyGroup
        public int UserId { get; set; } // Foreign key to User
        public string Role { get; set; }
        public StudyGroup Group { get; set; } // Navigation property to StudyGroup
        public User User { get; set; } // Navigation property to User
    }
}
