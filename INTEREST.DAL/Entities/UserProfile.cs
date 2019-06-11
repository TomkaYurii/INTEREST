using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static INTERESTS.DAL.Enums.GenderEnums;

namespace INTERESTS.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        public String Location { get; set; }
        public DateTime Birthday { get; set; }
        public Genders Gender { get; set; }
        public String Avatar { get; set; }

        public IList<UserCategory> UserCategories { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Photo> Photos { get; set; }

        public User User { get; set; }
    }
}
