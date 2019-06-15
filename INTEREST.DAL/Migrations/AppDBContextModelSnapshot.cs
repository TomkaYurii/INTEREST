﻿// <auto-generated />
using System;
using INTEREST.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace INTEREST.DAL.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("INTEREST.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.CategoryEvent", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("EventId");

                    b.HasKey("CategoryId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("CategoryEvent");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventName");

                    b.Property<string>("EventText");

                    b.Property<DateTime>("EventTime");

                    b.Property<string>("Location");

                    b.Property<string>("UserId");

                    b.Property<string>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("InternalId");

                    b.Property<string>("MessageText");

                    b.Property<DateTime>("MessageTime");

                    b.Property<int>("StatusMessageId");

                    b.Property<string>("UserId");

                    b.Property<string>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("StatusMessageId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventId");

                    b.Property<int?>("EventId1");

                    b.Property<string>("URL");

                    b.Property<string>("UserId");

                    b.Property<string>("UserProfileId");

                    b.HasKey("Id");

                    b.HasIndex("EventId1");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.StatusMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusMessageText");

                    b.HasKey("Id");

                    b.ToTable("StatusMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusMessageText = "Message is created"
                        },
                        new
                        {
                            Id = 2,
                            StatusMessageText = "Message is edited"
                        },
                        new
                        {
                            Id = 3,
                            StatusMessageText = "Message is deleted"
                        },
                        new
                        {
                            Id = 4,
                            StatusMessageText = "Message is deleted by admin"
                        });
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.UserCategory", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("CategoryId");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.UserProfile", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Gender");

                    b.Property<string>("Location");

                    b.Property<bool>("Online");

                    b.Property<DateTime>("TimeLogin");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ff4a9ee3-df66-4a6c-8a57-609193b74f02",
                            ConcurrencyStamp = "dd5142d0-5493-47cb-9e78-303d26d9bd85",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "a69b5eaa-7deb-4c4d-bcf0-302e04da575f",
                            ConcurrencyStamp = "424b85b1-855c-463e-bba7-7210b373c47b",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.CategoryEvent", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.Category", "Category")
                        .WithMany("CategoryEvents")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("INTEREST.DAL.Entities.Event", "Event")
                        .WithMany("CategoryEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.City", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Event", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.UserProfile", "UserProfile")
                        .WithMany("Events")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Message", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.Event", "Event")
                        .WithMany("Messages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("INTEREST.DAL.Entities.StatusMessage", "StatusMessage")
                        .WithMany("Messages")
                        .HasForeignKey("StatusMessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("INTEREST.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("INTEREST.DAL.Entities.UserProfile")
                        .WithMany("Messages")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.Photo", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.Event", "Event")
                        .WithMany("Photos")
                        .HasForeignKey("EventId1");

                    b.HasOne("INTEREST.DAL.Entities.UserProfile", "UserProfile")
                        .WithMany("Photos")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.UserCategory", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.Category", "Category")
                        .WithMany("UserCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("INTEREST.DAL.Entities.UserProfile", "UserProfile")
                        .WithMany("UserCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("INTEREST.DAL.Entities.UserProfile", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("INTEREST.DAL.Entities.UserProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("INTEREST.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("INTEREST.DAL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
