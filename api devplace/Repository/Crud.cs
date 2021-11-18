﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevPlace.Blog.API.Domain.Respositorio;
using Microsoft.EntityFrameworkCore;
using DevPlace.Blog.API.Repository;
using System.Linq.Expressions;

namespace DevPlace.Blog.API.Repository
{
    public class Crud
    {
        public class Repository<T>
             where T : EntityBase

        {
            private readonly DbContextApi _context;
            private readonly DbSet<T> _dbSet;

            public Repository(DbContextApi context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public async Task CreateAsync(T entity)
            {
                _dbSet.Add(entity);
                //await _context.SaveChangesAsync();
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(T entity)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                    _dbSet.Attach(entity);

                _dbSet.Remove(entity);
                //await _context.SaveChangesAsync();
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(int id)
            {
                var entity = await GetAsync(id);
                await DeleteAsync(entity);
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }

            public async Task<T> GetAsync(int id)
            {
                var entity = await _dbSet.FindAsync(id);
                return entity;
            }

            public async Task UpdateAsync(T entity)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                    _dbSet.Attach(entity);

                _context.Entry(entity).State = EntityState.Modified;

                //await _context.SaveChangesAsync();
                await Task.CompletedTask;
            }

            private bool _disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                _disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }

}

