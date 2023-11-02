using System;
using System.Collections.Generic;
using System.Linq;
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
            if (author.Name.Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long");
            if (repo.GetAll()
                    .FirstOrDefault(u => author.Name.Equals(author.Name, StringComparison.OrdinalIgnoreCase)) ==
                null)
                throw new ArgumentException("Name already exists");
            repo.Create(author);
        }

        public Author GetByName(string authorname)
        {
            return repo.GetAll().FirstOrDefault(u => u.Name == authorname);
        }

        public bool IsauthorExists(string authorname)
        {
            throw new NotImplementedException();
        }

        public List<Quote> GetauthorQuotes(int authorID)
        {
            throw new NotImplementedException();
        }

        public void CreateQuote(int authorID)
        {
            throw new NotImplementedException();
        }

        public void DeleteauthorQuotes(int authorID)
        {
            throw new NotImplementedException();
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
    }
}