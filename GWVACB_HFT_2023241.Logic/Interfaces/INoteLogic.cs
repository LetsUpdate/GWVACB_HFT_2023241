using System.Collections.Generic;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface INoteLogic:ICrudLogic<Note>
    {
        //Note Statistics
        public int GetAvgNoteLenght();
        public List<Note> GetNotesByUserName(string username);
        public List<Note> GetNotesWhereContentContains(string content);
        
        public List<Note> GetMostPerformingUserNotes();
        

    }
}