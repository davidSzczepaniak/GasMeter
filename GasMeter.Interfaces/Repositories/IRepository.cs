using System;
using System.Collections.Generic;
using System.Text;

namespace GasMeter.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(Guid id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        bool HasAny(Func<T, bool> predicate);

        int Count(Func<T, bool> predicate);
    }
}
