using System.Linq;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Repository
{
    public class QuoteRepository : Repository<Quote>, IRepository<Quote>
    {
        public QuoteRepository(QuoteDbContext dbContext) : base(dbContext)
        {
        }

        public override Quote Read(int id)
        {
            return _ctx.Quotes.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Quote entity)
        {
            _UpdateHelper(entity, entity.Id);
        }
    }
}