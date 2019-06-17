using INTEREST.DAL.EF;
using System;
using System.Collections.Generic;

namespace INTEREST.DAL.Entities
{
    public class UserProfile : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime Birthday { get; set; }
        public String Gender { get; set; }
        public String Avatar { get; set; }

        public Location Location { get; set; }

        public IList<UserCategory> UserCategories { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<Message> Messages { get; set; }

        public bool Online { get; set; }
        public DateTime TimeLogin { get; set; }
    }
}
