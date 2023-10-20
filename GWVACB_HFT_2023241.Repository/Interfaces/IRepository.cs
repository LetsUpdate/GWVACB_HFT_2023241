using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWVACB_HFT_2023241.Repository.Interfaces
{
    internal interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        T Read(int id);
        IQueryable<T> GetAll();
    }
}
