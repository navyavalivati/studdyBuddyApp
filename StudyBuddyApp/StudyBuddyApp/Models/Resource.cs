using System.ComponentModel.DataAnnotations;

namespace StudyBuddyApp.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [Required]
        public string Title { get; set; }

        public string FilePath { get; set; }

        public string Tags { get; set; }

        public DateTime UploadedAt { get; set; }

        // Foreign Keys
        public int StudyGroupId { get; set; }
        public string UploadedById { get; set; }

        // Navigation Properties
        public StudyGroup StudyGroup { get; set; }
        public ApplicationUser UploadedBy { get; set; }
    }
}
