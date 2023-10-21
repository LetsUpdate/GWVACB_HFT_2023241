using GWVACB_HFT_2023241.Models;
using System.Linq;

namespace GWVACB_HFT_2023241.Repository
{
    public class CommentRepository : Repository<Comment>, IRepository<Comment>
    {
        public CommentRepository(NoteDbContext dbContext) : base(dbContext)
        {
        }

        public override Comment Read(int id)
        {
            return _ctx.Comments.FirstOrDefault(x => x.CommentId == id);
        }

        public override void Update(Comment entity)
        {
            _UpdateHelper(entity, entity.CommentId);
        }

    }

}
