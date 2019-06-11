using INTERESTS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static INTERESTS.DAL.Enums.GenderEnums;

namespace INTEREST.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public String Location { get; set; }
        public Genders Gender { get; set; }
        public String Avatar { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
