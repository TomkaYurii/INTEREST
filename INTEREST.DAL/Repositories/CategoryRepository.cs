using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext db;

        public CategoryRepository(AppDBContext context)
        {
            this.db = context;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
