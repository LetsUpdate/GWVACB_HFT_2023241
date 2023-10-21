using GWVACB_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GWVACB_HFT_2023241.Repository
{
    public class NoteRepository : Repository<Note>, IRepository<Note>
    {
        public NoteRepository(NoteDbContext dbContext) : base(dbContext)
        {
        }

        public override Note Read(int id)
        {
            return _ctx.Notes.FirstOrDefault(x => x.NoteId == id);
        }

        public override void Update(Note entity)
        {
            _UpdateHelper(entity, entity.NoteId);
        }

    }

}
