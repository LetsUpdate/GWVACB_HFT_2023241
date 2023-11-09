using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Castle.Core.Internal;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;

namespace GWVACB_HFT_2023241.Logic
{
    public class AuthorLogic : IauthorLogic
    {
        private readonly IRepository<Author> repo;

        public AuthorLogic(IRepository<Author> repo)
        {
            this.repo = repo;
        }

        public void Create(Author author)
        {

            if(author.Age is <5 or >128)
                throw new ArgumentException("Age must be between 5 and 128");
            if (author.Name.Length is < 3 or > 16)
                throw new ArgumentException("Name must be at least 3 to 16 characters long");
            
            if (repo.GetAll()
                    .FirstOrDefault(u => u.Name.Equals(author.Name, StringComparison.OrdinalIgnoreCase)) !=
                null)
                throw new ArgumentException("Name already exists");
            if(author.Country.Length is < 2 or > 16)
                throw new ArgumentException("Country must be at least 2 to 16 characters long");
            
            repo.Create(author);
        }
        public Author GetById(int id)
        {
            return repo.Read(id);
        }

        public void Update(Author author)
        {
            repo.Update(author);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Author> GetAll()
        {
            return repo.GetAll();
        }

        public List<NameValue> GetQuoteCountByAuthor()
        {
            return repo.GetAll().Select(s => new NameValue() { Name = s.Name, Value = s.Quotes.Count }).ToList();
        }

        public List<Quote> GetOldestAuthorQuotes()
        {
            return repo.GetAll().FirstOrDefault(author => author.Age==repo.GetAll().Max(m=>m.Age))?.Quotes.ToList();
        }
        public Author GetAuthorWithMostWords()
        {
            return repo.GetAll().OrderByDescending(o => o.Quotes.Sum(s => s.Content.Length)).FirstOrDefault();
        }

        public List<NameValue> GetAvgQuoteLengthByAuthor()
        {
            return repo.GetAll().Select(s=>new NameValue(){Name = s.Name, Value = (int)s.Quotes.Average(a=>a.Content.Length)}).ToList();
        }
    }
}