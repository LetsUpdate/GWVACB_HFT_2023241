using System;
using System.Collections.Generic;
using System.Linq;
using GWVACB_HFT_2023241.Models;
using GWVACB_HFT_2023241.Repository;

namespace GWVACB_HFT_2023241.Logic
{
    public class NoteLogic : INoteLogic
    {
        private readonly IRepository<Note> repo;

        public NoteLogic(IRepository<Note> repo)
        {
            this.repo = repo;
        }

        public void Create(Note note)
        {
            repo.Create(note);
        }

        public void Update(Note note)
        {
            repo.Update(note);
        }

        public Note GetById(int id)
        {
            return repo.Read(id);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public IQueryable<Note> GetAll()
        {
            return repo.GetAll();
        }


    }
}