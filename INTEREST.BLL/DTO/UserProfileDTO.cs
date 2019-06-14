using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class UserProfileDTO
    {
        public User GetUser { get; set; }
        public List<Event> Events { get; set; }
    }
}
