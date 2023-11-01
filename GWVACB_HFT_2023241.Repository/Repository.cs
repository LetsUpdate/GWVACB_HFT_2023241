using System.Linq;

namespace GWVACB_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected NoteDbContext _ctx;

        public Repository(NoteDbContext dbContext)
        {
            _ctx = dbContext;
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Remove(Read(id));
            _ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _ctx.Set<T>();
        }

        public abstract T Read(int id);


        public abstract void Update(T entity);

        protected void _UpdateHelper(T entity, int id)
        {
            var old = Read(id);
            foreach (var prop in old.GetType().GetProperties()) prop.SetValue(old, prop.GetValue(entity));
            _ctx.SaveChanges();
        }
    }
}