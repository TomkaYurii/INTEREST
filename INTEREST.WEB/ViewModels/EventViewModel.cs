using INTEREST.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public string country { get; set; }
        [Required]
        public string city_state { get; set; }


        public IFormFile formFile { get; set; }


        public List<string> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }

        public string OwnerId { get; set; }
        public string URL { get; set; }
    }
}
