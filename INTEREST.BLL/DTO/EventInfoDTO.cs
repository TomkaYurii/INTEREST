using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.BLL.DTO
{
    public class EventInfoDTO
    {
        public string UserName { get; set; }
        public string EventName { get; set; }
        public string EventText { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public List<string> Categories { get; set; }
        public List<string> SelectedCategories { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string URL { get; set; }
    }
}
