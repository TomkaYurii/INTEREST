using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class UserProfileDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AvatarUrl { get; set; }
        public User GetUser { get; internal set; }

        //public User GetUser { get; set; }
        //public List<Event> Events { get; set; }
    }
}
