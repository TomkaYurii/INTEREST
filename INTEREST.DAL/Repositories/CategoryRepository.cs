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

        //public List<Category> CategoriesByUser(string id)
        //{
        //    List<Category> categories = new List<Category>();
        //    foreach (var item in context..UserProfileCategories.Where(x => x.UserId == id))
        //    {
        //        categories.Add(context.Categories.FirstOrDefault(x => x.Id == item.CategoryId));
        //    }
        //    return categories;
        //}

        public Category GetByTitle(string title)
        {
            return context.Categories.FirstOrDefault(x => x.Name == title);
        }
    }
}
