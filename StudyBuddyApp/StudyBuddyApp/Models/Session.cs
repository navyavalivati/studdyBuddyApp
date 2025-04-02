namespace StudyBuddyApp.Models
{
    public class Session
    {
        public int SessionId { get; set; } // Primary key
        public int GroupId { get; set; } // Foreign key to StudyGroup
        public string Topic { get; set; } 
        public DateTime StartTime { get; set; } 
        public string Location { get; set; } 
        public StudyGroup Group { get; set; } // Navigation property to StudyGroup
    }
}
