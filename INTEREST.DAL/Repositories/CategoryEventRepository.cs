using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class CategoryEventRepository : BaseRepository<CategoryEvent>, ICategoryEventRepository
    {
        public CategoryEventRepository(AppDBContext context) : base(context)
        {
        }

        public IQueryable<CategoryEvent> FindByEventId(int id)
        {
            return context.CategoryEvents.Where(x => x.EventId == id);
        }
    }
}
 