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
            if( repo.GetAll().Select(u => u.Username).Contains(user.Username))
                throw new Exception("Username already exists");
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
    }
}
