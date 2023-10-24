using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface IUserLogic:ICrudLogic<User>
    {
        public User GetByName(string username);
    }
}