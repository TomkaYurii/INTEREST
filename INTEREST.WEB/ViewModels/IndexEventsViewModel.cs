using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class IndexEventsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public List<List<string>> Selected_Categories { get; set; }
        public List<int> Count_Subscribers { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterEventsViewModel FilterEventsViewModel { get; set; }
        public SortEventsViewModel SortEventsViewModel { get; set; }
    }
}
