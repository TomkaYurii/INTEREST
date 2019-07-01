using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class CreateMessageViewModel
    {
        [Required]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Message text is required.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Your message")]
        public string MessageText { get; set; }

        public int ProdileId { get; set; }
    }
}
