namespace StudyBuddyApp.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    namespace StudyBuddyApp.Models
    {
        public class AppDbContext : IdentityDbContext<ApplicationUser>
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            //public DbSet<User> Users { get; set; }
            public DbSet<StudyGroup> StudyGroups { get; set; }
            public DbSet<GroupMember> GroupMembers { get; set; }
            public DbSet<Session> Sessions { get; set; }
            public DbSet<Resource> Resources { get; set; }
        }
    }

}
