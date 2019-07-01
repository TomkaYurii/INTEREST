using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class SortEventsViewModel
    {
        public EventSortState TitleSort { get; private set; }
        public EventSortState Current { get; private set; }

        public SortEventsViewModel(EventSortState sortOrder)
        {
            TitleSort = sortOrder == EventSortState.TitleAsc ? EventSortState.TitleDesc : EventSortState.TitleAsc;
            Current = sortOrder;
        }
    }
}
