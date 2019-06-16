using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(AppDBContext context) : base(context)
        {
        }

        public Location FindClone(Location clone)
        {
            return entity.FirstOrDefault(x => x.Country == clone.Country && x.City == clone.City);
        }
    }
}
