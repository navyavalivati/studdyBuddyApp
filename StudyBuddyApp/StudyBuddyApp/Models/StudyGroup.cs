using Microsoft.Identity.Client;

namespace StudyBuddyApp.Models
{
    public class StudyGroup
    {
        public int StudyGroupId { get; set; } //primary key
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public int CreatedById { get; set; } // Foreign key to User
        public User CreatedBy { get; set; } // Navigation property to User
    }
}
