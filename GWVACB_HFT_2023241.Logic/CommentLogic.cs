using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;

namespace GWVACB_HFT_2023241.Logic
{
    public class CommentLogic:ICommentLogic
    {
        private IRepository<Comment> repo;

        public CommentLogic(IRepository<Comment> repo)
        {
            this.repo = repo;
        }
        public void Create(Comment comment)
        {
            repo.Create(comment);
        }
        public void Update(Comment comment)
        {
            repo.Update(comment);
        }
        public Comment GetById(int id)
        {
            return repo.Read(id);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}