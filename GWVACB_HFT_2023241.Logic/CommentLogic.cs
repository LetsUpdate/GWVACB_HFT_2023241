using System.Linq;
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

        public void Create(Comment Quote)
        {
            repo.Create(Quote);
        }

        public void Update(Comment Quote)
        {
            repo.Update(Quote);
        }

        public Comment GetById(int id)
        {
            return repo.Read(id);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return repo.GetAll();
        }
    }
}