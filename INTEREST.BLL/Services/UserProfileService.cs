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

        //GET INFO ABOUT 1 user
        public UserProfileDTO GetProfile(User user)
        {
            var profile = Database.UserProfileRepository.GetById(user.ProfileId);
            var location = Database.LocationRepository.GetById(profile.Id);

            return new UserProfileDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Birthday = profile.Birthday,
                City = location.City,
                Country = location.Country,
                Gender = profile.Gender
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
