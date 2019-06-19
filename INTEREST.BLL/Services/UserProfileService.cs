using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using INTEREST.DAL.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

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

        //GET ALL USERS
        public List<UserProfileDTO> GetUsers()
        {
            var profiles = Database.UserProfileRepository.GetAll()
                .Include(p => p.User)
                .Include(p => p.Location)
                .ToList();

            var result = new List<UserProfileDTO>();

            foreach (var p in profiles)
            {
                result.Add(new UserProfileDTO
                {
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

        // GET INFO ABOUT 1 user by name
        //public UserProfileDTO FindProfileByUserName(string UserName)
        //{
        //    User user = Database.UserProfileRepository.FindByUserName(UserName);
        //    UserProfileDTO profile = new UserProfileDTO()
        //    {
        //        GetUser = user
        //    };
        //    return profile;
        //}

        //GET INFO ABOUT 1 user
        public UserProfileDTO GetProfile(User user)
        {
            var profile = Database.UserProfileRepository.GetById(user.ProfileId);
            var location = Database.LocationRepository.GetById(profile.LocationId.Value);
            var avatar = Database.PhotoRepository.GetById(profile.PhotoId.Value);

            return new UserProfileDTO
            {
                UserName = user.UserName,
                Email = user.Email,

                PhoneNumber = user.PhoneNumber,
                Birthday = profile.Birthday,
                City = location?.City,
                Country = location?.Country,
                Gender = profile.Gender,
                AvatarUrl = avatar?.URL
            };
        }





        public UserProfile GetProfileByName(User user)
        {
            return Database.UserProfileRepository.GetById(user.ProfileId);
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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
