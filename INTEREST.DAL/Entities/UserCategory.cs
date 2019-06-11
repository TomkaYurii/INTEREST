using System;
using System.Collections.Generic;
using System.Text;

namespace INTERESTS.DAL.Entities
{
    public class UserCategory
    {
        public string UserId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
