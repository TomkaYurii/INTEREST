﻿using INTEREST.DAL.Interfaces;
using INTERESTS.DAL.EF;
using INTERESTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly AppDBContext Database;

        public UserProfileManager(AppDBContext db)
        {
            Database = db;
        }

        public void Create(UserProfile userprofile)
        {
            Database.UserProfiles.Add(userprofile);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}