using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Entities
{
    public class CategoryEvent
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
