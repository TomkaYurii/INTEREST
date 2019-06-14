using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class CreateEventViewModel
    {
        [Required(ErrorMessage = "Message text is required.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Your message:")]
        public string EventText { get; set; }

        public string UserId { get; set; }
    }
}
