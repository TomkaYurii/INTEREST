using INTEREST.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class EventDTO
    {
        public string UserId { get; set; }
        public string EventName { get; set; }
        public string EventText { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<string> Categories { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int UserProfileId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
