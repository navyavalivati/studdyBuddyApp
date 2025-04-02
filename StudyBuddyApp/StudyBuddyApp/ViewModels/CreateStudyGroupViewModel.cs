using System.ComponentModel.DataAnnotations;

namespace StudyBuddyApp.ViewModels
{
    public class CreateStudyGroupViewModel
    {
        [Required(ErrorMessage = "Group name is required")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
    }
}
