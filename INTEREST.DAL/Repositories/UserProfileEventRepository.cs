using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileEventRepository : BaseRepository<UserProfileEvent>, IUserProfileEventRepository
    {
        public UserProfileEventRepository(AppDBContext context) : base(context)
        {
        }
    }
}
