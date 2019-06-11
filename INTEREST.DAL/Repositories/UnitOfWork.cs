using INTEREST.DAL.Interfaces;
using INTERESTS.DAL.EF;
using INTERESTS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        public AppDBContext Database { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public IUserProfileRepository UserProfileRepository { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }

        public IdentityUnitOfWork(IUserProfileRepository _profileManager,
                                  AppDBContext db,
                                  SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  RoleManager<IdentityRole> roleManager)
        {
            Database = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
            UserProfileRepository = _profileManager;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    UserProfileRepository.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await Database.SaveChangesAsync();
        }
    }
}
