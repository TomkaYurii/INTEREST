using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class AllEventsDTO
    {
        public IQueryable<Event> events {get; set;}
        public List<List<Category>> selectedCategories { get; set; }
    }
}
