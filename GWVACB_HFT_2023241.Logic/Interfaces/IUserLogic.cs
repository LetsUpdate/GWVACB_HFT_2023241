using System.Collections.Generic;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface IauthorLogic : ICrudLogic<Author>
    {
        List<NameValue> GetQuoteCountByAuthor();
        List<Quote> GetOldestAuthorQuotes();
        public Author GetAuthorWithMostWords();
        List<NameValue> GetAvgQuoteLengthByAuthor();
    }
}