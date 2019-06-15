using INTEREST.DAL.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace INTEREST.DAL.EF
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<StatusMessage> StatusMessages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Admin Role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            );

            //Status of message
            modelBuilder.Entity<StatusMessage>().HasData(
                new StatusMessage() { Id = 1, StatusMessageText = "Message is created" },
                new StatusMessage() { Id = 2, StatusMessageText = "Message is edited" },
                new StatusMessage() { Id = 3, StatusMessageText = "Message is deleted" },
                new StatusMessage() { Id = 4, StatusMessageText = "Message is deleted by admin" }
                );
            
            // User-Category
            modelBuilder.Entity<UserCategory>()
                .HasKey(uc => new { uc.UserId, uc.CategoryId });
            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.UserProfile)
                .WithMany(u => u.UserCategories)
                .HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.Category)
                .WithMany(c => c.UserCategories)
                .HasForeignKey(uc => uc.CategoryId);

            // Category-Event
            modelBuilder.Entity<CategoryEvent>()
                .HasKey(ce => new { ce.CategoryId, ce.EventId });
            modelBuilder.Entity<CategoryEvent>()
                .HasOne(ce => ce.Category)
                .WithMany(c => c.CategoryEvents)
                .HasForeignKey(uc => uc.CategoryId);
            modelBuilder.Entity<CategoryEvent>()
                .HasOne(ce => ce.Event)
                .WithMany(c => c.CategoryEvents)
                .HasForeignKey(ce => ce.EventId);
        }
    }
}
