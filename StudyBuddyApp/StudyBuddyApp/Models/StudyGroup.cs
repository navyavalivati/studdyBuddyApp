using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StudyBuddyApp.Models
{
    public class StudyGroup
    {
        public int StudyGroupId { get; set; }

        [Required(ErrorMessage = "Group name is required")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        //[BindNever] // This tells ASP.NET: "Don’t try to bind this from the form"
        public string CreatedById { get; set; }

        //[BindNever] // Also skip navigation property binding
        public ApplicationUser CreatedBy { get; set; }
    }
}
