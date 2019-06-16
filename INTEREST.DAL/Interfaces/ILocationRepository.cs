using INTEREST.DAL.Entities;

namespace INTEREST.DAL.Interfaces
{
    public interface ILocationRepository : IBaseRepository<Location>
    {
        Location FindClone(Location clone);
    }
}
