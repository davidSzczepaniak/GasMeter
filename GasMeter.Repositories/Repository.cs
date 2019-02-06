﻿using GasMeter.Data;
using GasMeter.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GasMeter.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly GasMeterDbContext context;

        public Repository(GasMeterDbContext context)
        {
            this.context = context;
        }

        protected void Save() => context.SaveChanges();

        public int Count(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            Save();
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public bool HasAny(Func<T, bool> predicate)
        {
            return context.Set<T>().Any<T>(predicate);
        }
    }
}
