using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;

namespace INTEREST.DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetByTitle(string title);
        List<Category> UserCategories(string userName);

    }
}
