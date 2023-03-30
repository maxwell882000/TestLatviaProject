using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TestProject.Domain.Common
{
    public interface IGenericRepository<T> where T : class
    {

        T Update(T entity);
        void Update(IEnumerable<T> entity);
        T GetById(long id);
        abstract DbSet<T> GetAll();

        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        public void Commit();
        public delegate T CommitEventHandler();
        T SaveCommit(CommitEventHandler func);

        void changeState(T entity, EntityState state);

    }
}

