using System;
using System.Collections.Generic;
using System.Text;

namespace INTEREST.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

        void Save();
    }
}
