using System.Collections.Generic;
using GWVACB_HFT_2023241.Models;

namespace GWVACB_HFT_2023241.Logic
{
    public interface IQuoteLogic : ICrudLogic<Quote>
    {
        List<NameValue> GetQuoteCountByAuthor();

        List<Quote> ListQuotesByAuthor(int authorId);

        NameValue GetMostPopularQuote();
        
    }
}