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

        public UserProfileService(IUnitOfWork db)
        {
            Database = db;
        }

        public async Task<UserProfileDTO> FindUserProfileByUserName(string UserName)
        {
            User user = Database.UserProfileRepository.FindByUserName(UserName);
            UserProfileDTO userprofile = new UserProfileDTO()
            {
                GetUser = user
            };
            return userprofile;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
