using System.Linq;

namespace GWVACB_HFT_2023241.Logic
{
    public interface ICrudLogic<T>
    {
        public void Create(T note);

        public void Update(T note);

        public T GetById(int id);

        public void Delete(int id);
        public IQueryable<T> GetAll();
    }
}