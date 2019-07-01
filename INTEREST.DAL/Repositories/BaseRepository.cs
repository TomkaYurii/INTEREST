using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using INTEREST.DAL.Entities;

namespace INTEREST.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDBContext context;
        protected readonly DbSet<T> entity;

        public BaseRepository(AppDBContext _context)
        {
            context = _context;
            entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll() => entity;

        public T GetById(int id)
        {
            return entity.Find(id);
        }

        public T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.entity.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (this.entity.Contains(entity))
            {
                this.entity.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
