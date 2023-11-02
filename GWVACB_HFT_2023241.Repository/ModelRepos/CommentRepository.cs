using System.Linq;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Repository
{
    public class CommentRepository : Repository<Comment>, IRepository<Comment>
    {
        public CommentRepository(QuoteDbContext dbContext) : base(dbContext)
        {
        }

        public override Comment Read(int id)
        {
            return _ctx.Comments.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Comment entity)
        {
            _UpdateHelper(entity, entity.Id);
        }
    }
}