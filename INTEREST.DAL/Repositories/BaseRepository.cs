using INTEREST.DAL.Interfaces;
using INTERESTS.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INTEREST.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDBContext Database;
        protected readonly DbSet<T> entities;

        public BaseRepository(AppDBContext context)
        {
            Database = context;
            entities = context.Set<T>();
        }


        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Add(entity);
            //return entity;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException();
            }
            entities.Remove(entity);
            //return entity;
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

        public void Update(T entity)
        {
            if (entity == null)
                throw new NotImplementedException();
            entities.Update(entity);
           // return entity;
        }
    }
}
