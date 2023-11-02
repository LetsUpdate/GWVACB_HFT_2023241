using System.Linq;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Repository
{
    public class AuthorRepository : Repository<Author>, IRepository<Author>
    {
        public AuthorRepository(QuoteDbContext dbContext) : base(dbContext)
        {
        }

        public override Author Read(int id)
        {
            return _ctx.authors.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Author entity)
        {
            _UpdateHelper(entity, entity.Id);
        }
    }
}