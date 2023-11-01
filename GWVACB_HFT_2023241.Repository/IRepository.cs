using System.Linq;

namespace GWVACB_HFT_2023241.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T Read(int id);
        IQueryable<T> GetAll();
    }
}