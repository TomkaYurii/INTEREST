using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEREST.WEB.ViewModels
{
    public class SortEventsViewModel
    {
        public EventSortState TitleSort { get; private set; }
        public EventSortState AuthorSort { get; private set; }
        public EventSortState CountrySort { get; private set; }
        public EventSortState CitySort { get; private set; }
        public EventSortState Current { get; private set; }

        public SortEventsViewModel(EventSortState sortOrder)
        {
            TitleSort = sortOrder == EventSortState.TitleAsc ? EventSortState.TitleDesc : EventSortState.TitleAsc;
            AuthorSort = sortOrder == EventSortState.AuthorAsc ? EventSortState.AuthorDesc : EventSortState.AuthorAsc;
            CountrySort = sortOrder == EventSortState.CountryAsc ? EventSortState.CountryDesc : EventSortState.CountryAsc;
            CitySort = sortOrder == EventSortState.CityAsc ? EventSortState.CityDesc : EventSortState.CityAsc;
            Current = sortOrder;
        }
    }
}
