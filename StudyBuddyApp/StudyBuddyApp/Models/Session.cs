using System.ComponentModel.DataAnnotations;

namespace StudyBuddyApp.Models
{
    public class Session
    {
        public int SessionId { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public string Location { get; set; }

        public int StudyGroupId { get; set; }

        public StudyGroup StudyGroup { get; set; }

        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
    }
}
