using System.Collections.Generic;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface IQuoteLogic : ICrudLogic<Quote>
    {
        List<NameValue> GetQuoteCountByauthor();

        List<Quote> ListQuotesByauthor(int authorId);

        NameValue GetMostPopularQuote();
        List<NameValue> GetQuoteCountByAuthor();
    }
}