using System.Collections.Generic;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface IauthorLogic : ICrudLogic<Author>
    {
        public Author GetByName(string authorname);
        public bool IsauthorExists(string authorname);
        public List<Quote> GetauthorQuotes(int authorID);
        public void CreateQuote(int authorID);
        public void DeleteauthorQuotes(int authorID);
    }
}