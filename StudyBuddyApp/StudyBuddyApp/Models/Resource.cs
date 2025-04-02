namespace StudyBuddyApp.Models
{
    public class Resource
    {
        public int ResourceId { get; set; } // Primary key
        public int GroupId { get; set; } // Foreign key to StudyGroup
        public int UploadedById { get; set; } // Foreign key to User
        public string Title { get; set; } // Title of the resource
        public string FilePath { get; set; } 
        public string Tags { get; set; }
        public StudyGroup Group { get; set; } // Navigation property to StudyGroup
        public User UploadedBy { get; set; } // Navigation property to User

    }
}
