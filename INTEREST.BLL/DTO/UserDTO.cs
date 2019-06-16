using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class UserDTO
    {
        //User entity
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        //UserProfile entity
        public string Id { get; set; }
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        public String Gender { get; set; }

        public string Role { get; set; }
    }
}
