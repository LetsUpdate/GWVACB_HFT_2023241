using System.Collections.Generic;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface IUserLogic:ICrudLogic<User>
    {
        public User GetByName(string username);
        public bool IsUserExists(string username);
        public List<Note> GetUserNotes(int userID);
        public void CreateNote(int userID);
        public void DeleteUserNotes(int userID);
    }
}