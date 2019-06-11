using INTEREST.DAL.Interfaces;
using INTERESTS.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly AppDBContext Database;
        protected readonly DbSet<T> entities;

        public Repository(AppDBContext context)
        {
            Database = context;
            entities = context.Set<T>();
        }


        public T Add(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Remove(entity);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public void Save()
        {
            Database.SaveChanges();
        }

        public T Update(T entity)
        {
            if (entity == null)
                throw new NotImplementedException();
            entities.Update(entity);
            return entity;
        }
    }
}
