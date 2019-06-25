using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext context) : base(context)
        {
        }

        public Category GetByTitle(string title)
        {
            return context.Categories.FirstOrDefault(x => x.Name == title);
        }

        public List<Category> UserCategories(string userName)
        {
            List<Category> categories = new List<Category>();
            User user = context.Users.FirstOrDefault(x => x.UserName == userName);
            categories = context.Categories.Where(c => c.UserProfileCategories
                                .Any(e => e.UserProfileId == user.ProfileId))
                                .ToList();
            return categories;
        }

        public List<Category> EventCategories(int id)
        {
            List<Category> categories = new List<Category>();
            categories = context.Categories.Where(c => c.CategoryEvents
                                .Any(e => e.EventId == id))
                                .ToList();
            return categories;
        }

    }
}
