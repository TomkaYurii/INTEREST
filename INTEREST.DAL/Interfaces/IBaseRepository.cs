﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace INTEREST.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);

        void Save();
    }
}
