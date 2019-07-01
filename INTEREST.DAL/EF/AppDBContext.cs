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
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserProfileCategory> UserProfileCategories { get; set; }
        public DbSet<CategoryEvent> CategoryEvents { get; set; }
        public DbSet<UserProfileEvent> UserProfileEvents { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
            .Entity<User>()
            .HasOne(u => u.UserProfile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            // Admin Role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            );

            // Event - UserProfile
            modelBuilder.Entity<Event>()
                .HasOne(e => e.UserProfile)
                .WithMany(up => up.MyEvents)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.SetNull);

            //User - Category
            modelBuilder.Entity<UserProfileCategory>()
                .HasKey(uc => new { uc.UserProfileId, uc.CategoryId });
            modelBuilder.Entity<UserProfileCategory>()
                .HasOne(uc => uc.UserProfile)
                .WithMany(u => u.UserProfileCategories)
                .HasForeignKey(uc => uc.UserProfileId);
            modelBuilder.Entity<UserProfileCategory>()
                .HasOne(uc => uc.Category)
                .WithMany(c => c.UserProfileCategories)
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
                .WithMany(k => k.CategoryEvents)
                .HasForeignKey(ce => ce.EventId);

            // UserProfileEvents
            modelBuilder.Entity<UserProfileEvent>()
            .HasKey(uc => new { uc.UserProfileId, uc.EventId });
            modelBuilder.Entity<UserProfileEvent>()
                .HasOne(ue => ue.UserProfile)
                .WithMany(u => u.UserProfileEvents)
                .HasForeignKey(ue => ue.UserProfileId);
            modelBuilder.Entity<UserProfileEvent>()
                .HasOne(ue => ue.Event)
                .WithMany(c => c.UserProfileEvents)
                .HasForeignKey(ue => ue.EventId);
        }
    }
}
