using INTEREST.DAL.Interfaces;
using INTEREST.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDBContext _context;
        protected readonly DbSet<T> entity;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
            entity = context.Set<T>();
        }

        public IQueryable<T> GetAll() => entity;

        public T GetById(int id) => entity.SingleOrDefault(e => e.Id == id);

        public T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.entity.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
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
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
