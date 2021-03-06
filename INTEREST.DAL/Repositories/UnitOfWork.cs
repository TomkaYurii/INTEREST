﻿using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace INTEREST.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext db;

        public UserManager<User> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }

        private IUserProfileRepository _userProfileRepository;
        private IEventRepository _eventRepository;
        private IMessageRepository _messageRepository;
        private ICategoryRepository _categoryRepository;
        private ILocationRepository _locationRepository;
        private IPhotoRepository _photoRepository;
        private IUserProfileCategoryRepository _userProfileCategoryRepository;
        private ICategoryEventRepository _categoryEventRepository;
        private IUserProfileEventRepository _userProfileEventRepository;

        public UnitOfWork(AppDBContext context,
                                  UserManager<User> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  SignInManager<User> signInManager
                                  )
        {
            db = context;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }


        public IUserProfileRepository UserProfileRepository =>
            _userProfileRepository ?? (_userProfileRepository = new UserProfileRepository(db));
        public ICategoryRepository CategoryRepository =>
            _categoryRepository ?? (_categoryRepository = new CategoryRepository(db));
        public IEventRepository EventRepository =>
            _eventRepository ?? (_eventRepository = new EventRepository(db));
        public IMessageRepository MessageRepository =>
            _messageRepository ?? (_messageRepository = new MessageRepository(db));
        public ILocationRepository LocationRepository =>
            _locationRepository ?? (_locationRepository = new LocationRepository(db));
        public IPhotoRepository PhotoRepository =>
            _photoRepository ?? (_photoRepository = new PhotoRepository(db));
        public ICategoryEventRepository CategoryEventRepository =>
            _categoryEventRepository ?? (_categoryEventRepository = new CategoryEventRepository(db));
        public IUserProfileCategoryRepository UserProfileCategoryRepository =>
            _userProfileCategoryRepository ?? (_userProfileCategoryRepository = new UserProfileCategoryRepository(db));
        public IUserProfileEventRepository UserProfileEventRepository =>
            _userProfileEventRepository ?? (_userProfileEventRepository = new UserProfileEventRepository(db));


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
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
