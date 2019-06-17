using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using INTEREST.DAL.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork Database;

        public UserProfileService(IUnitOfWork uow)
        {
            this.Database = uow;
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
                    Country = p.Location.Country,
                    City = p.Location.City
                    //AvatarUrl = p.Avatar?.Url
                });
            }
            return result;
        }

        //GET ONE USER INFORMATION
        //public UserProfileDTO GetProfile(User user)
        //{
        //    var profile = Database.UserProfileRepository.GetById(user.ProfileId);

        //    return new UserProfileDTO
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber,
        //        //Birthday = profile.Birthday,
        //        //City = profile.Location.City,
        //        //Country = profile.Location.Country,
        //        //Gender = profile.Gender
        //    };
        //}

        public async Task<UserProfileDTO> FindProfileByUserName(string UserName)
        {
            User user = Database.UserProfileRepository.FindByUserName(UserName);

            UserProfileDTO profile = new UserProfileDTO() {
                GetUser = user
            };
            return profile;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
