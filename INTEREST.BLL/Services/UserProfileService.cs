﻿using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using INTEREST.DAL.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using INTEREST.BLL.Infrastructure;
using System;
using Microsoft.AspNetCore.Identity;

namespace INTEREST.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork Database;
        private readonly IHostingEnvironment _appEnvironment;

        public UserProfileService(IUnitOfWork uow, IHostingEnvironment hostingEnvironment)
        {
            this.Database = uow;
            _appEnvironment = hostingEnvironment;
        }

        public async Task<OperationDetails> EditProfile(UserProfileDTO model)
        {
            User user = await Database.UserManager.FindByIdAsync(model.UserId);
            UserProfile profile = Database.UserProfileRepository.GetById(user.ProfileId);

            if (model.UserName != null)
            {
                User clone = await Database.UserManager.FindByNameAsync(model.UserName);
                if (model.UserName != user.UserName && clone != null)
                    return new OperationDetails(false, "Username is being use", "");
                user.UserName = model.UserName;
            }
            if (model.Email != null)
            {
                User clone = await Database.UserManager.FindByEmailAsync(model.Email);
                if (model.Email != user.Email && clone != null)
                    return new OperationDetails(false, "Username is being use", "");
                user.Email = model.Email;
            }

            user.PhoneNumber = model.PhoneNumber;
            profile.Birthday = model.Birthday; 

            if (model.Country != null && model.City != null)
            {
                Location location = new Location { City = model.City, Country = model.Country };
                if (Database.LocationRepository.FindClone(location) == null)
                {
                    Location newlocation = Database.LocationRepository.Create(location);
                    profile.Location = newlocation;
                }
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public async Task DeleteUser(string email)
        {
            var user = await Database.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                await Database.UserManager.DeleteAsync(user);
            }
        }

        public async Task AddAvatar(string url, UserProfile userProfile)
        {
            if (userProfile.Avatar.URL != "Default")
            {
                Photo photo = Database.PhotoRepository.GetById(userProfile.PhotoId.Value);
                if (System.IO.File.Exists(_appEnvironment.WebRootPath + photo.URL))
                {
                    System.IO.File.Delete(_appEnvironment.WebRootPath + photo.URL);
                }
                photo.URL = url;
                userProfile.Avatar = photo;
            }
            else
            {
                Photo photo = Database.PhotoRepository.Create(new Photo { URL = url });
                userProfile.Avatar = photo;
            }
            await Database.SaveAsync();
        }

        public UserProfileDTO GetProfile(string user_name)
        {
            User profile = Database.UserProfileRepository.FindByUserName(user_name);
            return new UserProfileDTO
            {
                UserId = profile.Id,
                UserName = profile.UserName,
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber,
                Birthday = profile.UserProfile.Birthday,
                City = profile.UserProfile?.Location?.City,
                Country = profile.UserProfile?.Location?.Country,
                Gender = profile.UserProfile.Gender,
                AvatarUrl = profile.UserProfile?.Avatar?.URL
            };
        }

        public List<UserProfileDTO> GetUsersAsync()
        {
            var profiles = Database.UserProfileRepository.GetAll()
                .Include(p => p.User)
                .Include(p => p.Location)
                .Include(p => p.Avatar)
                .ToList();
            var result = new List<UserProfileDTO>();
            foreach (var p in profiles)
            {
                result.Add(new UserProfileDTO
                {
                    UserId = p.UserId,
                    UserName = p.User.UserName,
                    Email = p.User.Email,
                    PhoneNumber = p.User.PhoneNumber,
                    Birthday = p.Birthday,
                    Gender = p.Gender,
                    Country = p.Location?.Country,
                    City = p.Location?.City,
                    AvatarUrl = p.Avatar?.URL
                });
            }
            return result;
        }

        public User GetUserByName(string user)
        {
            return Database.UserProfileRepository.FindByUserName(user);
        }
    }
}
