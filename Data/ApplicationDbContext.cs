using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using ChatApp.Models;

namespace ChatApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Models.Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define your entity configurations, relationships, etc. here if needed
            modelBuilder.Entity<GroupMember>()
            .HasKey(gm => new { gm.GroupId, gm.UserId });
        }
    }
}
