using INTERESTS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

using static INTERESTS.DAL.Enums.GenderEnums;

namespace INTERESTS.DAL.EF
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Event> Events { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            );

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

            modelBuilder
                .Entity<UserProfile>()
                .Property(p => p.Gender)
                .HasConversion(
                    v => v.ToString(),
                    v => (Genders)Enum.Parse(typeof(Genders), v));
        }
    }
}
