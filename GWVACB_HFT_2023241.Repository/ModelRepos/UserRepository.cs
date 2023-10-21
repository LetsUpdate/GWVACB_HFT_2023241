using GWVACB_HFT_2023241.Models;
using System.Linq;

namespace GWVACB_HFT_2023241.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(NoteDbContext dbContext) : base(dbContext)
        {
        }

        public override User Read(int id)
        {
            return _ctx.Users.FirstOrDefault(x => x.UserId == id);
        }

        public override void Update(User entity)
        {
            _UpdateHelper(entity, entity.UserId);
        }

    }

}
