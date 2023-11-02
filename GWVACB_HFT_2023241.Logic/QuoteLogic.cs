using System;
using System.Collections.Generic;
using System.Linq;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;

namespace GWVACB_HFT_2023241.Logic
{
    public class QuoteLogic : IQuoteLogic
    {
        private readonly IRepository<Quote> repo;

        public QuoteLogic(IRepository<Quote> repo)
        {
            this.repo = repo;
        }

        public void Create(Quote quote)
        {
            repo.Create(quote);
        }

        public void Update(Quote quote)
        {
            repo.Update(quote);
        }

        public Quote GetById(int id)
        {
            return repo.Read(id);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Quote> GetAll()
        {
            return repo.GetAll();
        }

        public List<NameValue> GetQuoteCountByauthor()
        {
            return GetAll().GroupBy(g => g.Author.Name)
                .Select(s => new NameValue() { Name = s.Key, Value = s.Count() }).ToList();
        }

        public List<Quote> ListQuotesByauthor(int authorId)
        {
            return GetAll().Where(n=>n.Author.Id == authorId).ToList();
        }
        

        public NameValue GetMostPopularQuote()
        {
            return GetAll().Select(s => new NameValue() { Name = s.Title, Value = s.Comments.Count }).OrderByDescending(o => o.Value).FirstOrDefault();
        }


    }
}