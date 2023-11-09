using System;
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

        public void Create(Comment comment)
        {
            if (comment.Content.Length is < 3 or > 20)
                throw new ArgumentException("Content must be between 3 and 20 characters");
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

        public IQueryable<Comment> GetAll()
        {
            return repo.GetAll();
        }
    }
}