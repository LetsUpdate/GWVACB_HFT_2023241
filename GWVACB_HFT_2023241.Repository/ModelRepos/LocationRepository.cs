using System.Linq;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Repository
{
    public class LocationRepository : Repository<Location>, IRepository<Location>
    {
        public LocationRepository(NoteDbContext dbContext) : base(dbContext)
        {
        }

        public override Location Read(int id)
        {
            return _ctx.Locations.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Location entity)
        {
            _UpdateHelper(entity, entity.Id);
        }
    }
}