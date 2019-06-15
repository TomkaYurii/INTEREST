using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class DeleteMessageViewModel
    {
        [Required]
        public int IdEvent { get; set; }

        [Required]
        public int InternalId { get; set; }

        public string UserId { get; set; }
    }
}
