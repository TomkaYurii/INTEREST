using System.Collections.Generic;

namespace INTEREST.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);

        void Save();
    }
}
