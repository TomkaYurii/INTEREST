using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class EditProfileDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
