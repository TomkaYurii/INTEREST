using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.DAL.Interfaces
{
    public interface ICategoryEventRepository : IBaseRepository<CategoryEvent>
    {
        IQueryable<CategoryEvent> FindByEventId(int id);
    }
}
