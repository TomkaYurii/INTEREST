using INTEREST.BLL.DTO;
using INTEREST.BLL.Interfaces;
using INTEREST.DAL.Interfaces;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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

        public List<UserProfileDTO> Users()
        {
            var profiles = Database.UserProfileRepository.GetAll();
            var responce = new List<UserProfileDTO>();

            foreach (var p in profiles)
            {
                responce.Add(new UserProfileDTO
                {
                    UserName = p.User.UserName,
                    Email = p.User.Email
                    //PhoneNumber = p.User.PhoneNumber,
                    //Birthday = p.Birthday,
                    //City = p.City.Name,
                    //Country = p.City.Country.Name
                });
            }

            return responce;
        }

        public UserProfileDTO GetProfile(User u)
        {
            //var p = Database.UserProfileRepository.GetById(u.UserProfileId);

            return new UserProfileDTO
            {
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber

                //Birthday = p.Birthday,
                //City = p.Location.City,
                //Country = p.Location.Country,
                //Gender = p.Gender
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
