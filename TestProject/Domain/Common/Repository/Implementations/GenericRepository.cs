﻿using System;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Domain.Common
{
    public class GenericRepository<Context, T> : IGenericRepository<T>
       where T : class
       where Context : DbContext
    {
        protected readonly Context _context;
        protected readonly ILogger _logger;
        public GenericRepository(Context context, ILogger<GenericRepository<Context, T>> logger)
        {
            _context = context;
            this._logger = logger;
        }


        T IGenericRepository<T>.Update(T entity)
        {

            return _context.Set<T>().Update(entity).Entity;
        }


        T IGenericRepository<T>.Add(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
        }

        void IGenericRepository<T>.AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }



        DbSet<T> IGenericRepository<T>.GetAll()
        {
            return _context.Set<T>();
        }

        T IGenericRepository<T>.GetById(long id)
        {
            return _context.Set<T>().Find(id) ?? throw new Exception("ENTITY NOT EXISTS BY ID  : " + id);

        }

        void IGenericRepository<T>.Remove(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Set<T>().Remove(entity);
        }

        void IGenericRepository<T>.RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }


        public T SaveCommit(IGenericRepository<T>.CommitEventHandler func)
        {
            using var transaction = this._context.Database.BeginTransaction();
            try
            {
                T entity = func();
                this._context.SaveChanges();
                transaction.Commit();
                return entity;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }

        public void changeState(T entity, bool condition)
        {
            _context.Entry(entity).State = condition ? EntityState.Added : EntityState.Modified;
        }


        public void clone(T realObject, T copyObject)
        {
            var values = this._context.Entry(realObject).CurrentValues.Clone();
            this._context.Entry(copyObject).CurrentValues.SetValues(values);
        }

        async public Task<int> commitAsync()
        {
            return await this._context.SaveChangesAsync();
        }


        void IGenericRepository<T>.Commit()
        {
            _context.SaveChanges();
        }

        public void Update(IEnumerable<T> entity)
        {
            _context.Set<T>().UpdateRange(entity);
        }

        public void changeState(T entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

    }
}

