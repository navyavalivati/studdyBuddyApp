using Microsoft.AspNetCore.Identity;

namespace StudyBuddyApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string University { get; set; }
        public string Bio { get; set; }
    }
}
