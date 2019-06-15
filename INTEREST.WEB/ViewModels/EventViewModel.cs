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
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Event")]
        public string EventText { get; set; }

        [Display(Name = "Date of creation")]
        public DateTime EventTime { get; set; }
    }
}
