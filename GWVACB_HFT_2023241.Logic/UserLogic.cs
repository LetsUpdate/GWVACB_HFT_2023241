using System;
using System.Linq;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;

namespace GWVACB_HFT_2023241.Logic
{
    public class UserLogic:IUserLogic
    {
        private IRepository<User> repo;

        public UserLogic(IRepository<User> repo)
        {
            this.repo = repo;
        }
        
        public void Create(User user)
        {
            if(user.Username.Length<3)
                throw new ArgumentException("Username must be at least 3 characters long");
            if( repo.GetAll().Select(u => u.Username).Contains(user.Username))
                throw new ArgumentException("Username already exists");
            repo.Create(user);
        }
        public User GetByName(string username)
        {
            return repo.GetAll().Where(u => u.Username == username).FirstOrDefault();
        }
        public User GetById(int id)
        {
            return repo.Read(id);
        }
        public void Update(User user)
        {
            repo.Update(user);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<User> GetAll()
        {
            return repo.GetAll();
        }
    }
}
