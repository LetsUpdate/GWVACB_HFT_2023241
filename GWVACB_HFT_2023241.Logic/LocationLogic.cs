using System.Linq;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;

namespace GWVACB_HFT_2023241.Logic
{
    public class LocationLogic:ILocationLogic
    {
        private IRepository<Location> repo;

        public LocationLogic(IRepository<Location> repo)
        {
            this.repo = repo;
        }

        public void Create(Location note)
        {
            repo.Create(note);
        }

        public void Update(Location note)
        {
            repo.Update(note);
        }

        public Location GetById(int id)
        {
            return repo.Read(id);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Location> GetAll()
        {
            return repo.GetAll();
        }
    }
}